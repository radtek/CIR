const { app, BrowserWindow, Menu, Tray } = require('electron')
//main process
const path = require('path')
const url = require('url')
const nativeImage = require('electron').nativeImage
const iconPath = path.join(__dirname, './images/CIR_icon.png')
let demoIcon = nativeImage.createFromPath(iconPath)
let win
const fs = require('fs');
const { ipcMain } = require('electron');
const { globalShortcut } = require('electron');
const autoUpdater = require('electron').autoUpdater;
const os = require('os');
const log = require('electron-log');

// this should be placed at top of main.js to handle setup events quickly
if (handleSquirrelEvent(app)) {
    // squirrel event handled and app will exit in 1000ms, so don't do anything else
    return;
}

// configure logging
autoUpdater.logger = log;
autoUpdater.logger.transports.file.level = 'info';

let platform = 'win';
if (process.platform === 'darwin') {
    platform = 'osx';
}

//this will be used to create only one instance of application
var iShouldQuit = app.makeSingleInstance(function (commandLine, workingDirectory) {
    if (win) {
        if (win.isMinimized()) win.restore();
        win.show();
        win.focus();
    }
    return true;
});
if (iShouldQuit) { app.quit(); return; }

let tray = null

function createWindow() {
    win = new BrowserWindow({
        titleBarStyle: 'hidden', webPreferences: {
            preload: "./preload.js",
            icon: demoIcon,
            nodeIntegration: true
        }
    })
    win.maximize()
    win.setMenu(null);
    win.loadURL('file://' + __dirname + '/main.html');
    win.show()
    win.$ = win.jQuery = require('./node_modules/jquery/dist/jquery.min.js');
    win.on('close', function (event) {
        if (!app.isQuiting) {
            event.preventDefault()
            win.hide();
        }
        return false;
    })

    win.onload = () => {
        const $ = require('jquery')
        console.log($('body div').length)
    }
    // win.on('minimize',function(event){
    //     event.preventDefault()
    //     win.hide();
    // })
    appIcon = new Tray(iconPath)
    const contextMenu = Menu.buildFromTemplate([
        {
            label: 'Show App', click: function () {
                win.maximize()
                win.show();
            }
        },
        {
            label: 'Quit', click: function () {
                app.isQuiting = true;
                app.quit();
            }
        }
    ])
    // open App on right click
    appIcon.on('click', () => {
        win.maximize()
        win.show();
    })
    // set Tooltip of icon
    appIcon.setToolTip("CIR Offline App");
    // Call this again for Linux because we modified the context menu
    appIcon.setContextMenu(contextMenu);

    // win.webContents.openDevTools()
    const feedURL = 'https://cirprodblobstorage.blob.core.windows.net/cirappcontainer';
    autoUpdater.setFeedURL(feedURL);

    // trigger autoupdate check
    autoUpdater.checkForUpdates();

    ipcMain.on('autoupdate-init', function (event, arg) {
        ipcReady = true;
    });
}

//app.on('ready', createWindow)

app.on('ready', () => {
    createWindow(); 
    globalShortcut.register('CommandOrControl+F5', () => {
        win.reload();
    })
})

// app.on('window-all-closed', ()=>{
//     if(process.platform != 'darwin'){
//         app.quit()
//     }
// })

app.on('activate', () => {
    if (win == null) {
        createWindow()
    }
})


//-------------------------------------------------------------------
// Auto updates
//-------------------------------------------------------------------
const sendStatusToWindow = (text) => {
    win.webContents.send('ping', text);
};
filepath = process.env.APPDATA + "/CIR_Offline_App/log1.json";
autoUpdater.on('checking-for-update', () => {
});

autoUpdater.on('update-available', info => {
});

autoUpdater.on('update-not-available', info => {
});

autoUpdater.on('error', err => {
    filepath = process.env.APPDATA + "/CIR_Offline_App/log1.json"
    if (fs.existsSync(filepath)) {
        var data = fs.readFileSync(filepath, 'utf8');
        data = data + 'Error in auto-updater:' + err.toString() + '....';
        fs.writeFileSync(filepath, data);
    }
});
autoUpdater.on('download-progress', progressObj => {
    console.log( `Download speed: ${progressObj.bytesPerSecond} - Downloaded ${progressObj.percent}% (${progressObj.transferred} + '/' + ${progressObj.total} + )`
    );
});

autoUpdater.on('update-downloaded', info => {
});

autoUpdater.on('certificate-error', err => {
    if (fs.existsSync(filepath)) {
        var data = fs.readFileSync(filepath, 'utf8');
        data = data + 'certificate-error....';
        fs.writeFileSync(filepath, data);
    }
});

autoUpdater.on('update-downloaded', info => {
    // Wait 5 seconds, then quit and install
    // In your application, you don't need to wait 500 ms.
    // You could call autoUpdater.quitAndInstall(); immediately
    autoUpdater.quitAndInstall();
});

ipcMain.on('synchronous-message', (event, fileName) => {
    
})

// ipcMain.on('run-inspect-tool', (event,arg1) => {
//     console.log("run-inspect-tool-proxy");
//     var child = require('child_process').execFile;
//     var executablePath="C:\\Program Files\\7-Zip\\7zFM.exe";
//     var parameters=[""];
//     child(executablePath, parameters, function (err, data) {
//         console.log(err)
//         console.log(data.toString());
//     });
// });

ipcMain.on('clear-cache', (event,arg1) => {
    win.webContents.session.clearStorageData();
    win.reload();
    //clearAppDataCache();
});

// function clearAppDataCache() {
//     var chromeCacheDir = path.join(app.getPath('appData'), app.getName(), 'Cache');
//     if (fs.existsSync(chromeCacheDir)) {
//         var files = fs.readdirSync(chromeCacheDir);
//         for (var i = 0; i < files.length; i++) {
//             var filename = path.join(chromeCacheDir, files[i]);
//             if (fs.existsSync(filename)) {
//                 try {
//                     fs.unlinkSync(filename);
//                 }
//                 catch (e) {
//                     console.log(e);
//                 }
//             }
//         }
//     }
// }

// Handle install,uninstall,auto update features.
function handleSquirrelEvent(application) {
    if (process.argv.length === 1) {
        return false;
    }
    if (process.platform != 'win32') {
        return false;
    }

    function executeSquirrelCommand(args, done) {
        const cp = require('child_process');
        log.info('process.execPath...' + process.execPath);
        log.info('path exist: ' + fs.existsSync(path.resolve(path.dirname(process.execPath), '..', 'update.exe')));
        var updateDotExe = path.resolve(path.dirname(process.execPath), '..', 'update.exe');
        var child = cp.spawn(updateDotExe, args, { detached: true });
        child.on('close', function (code) {
            done();
        });
    };
    
    function install(done) {
        var target = path.basename(process.execPath);
        executeSquirrelCommand(["--createShortcut", target], done);
    };
    
    function uninstall(done) {
        var target = path.basename(process.execPath);
        executeSquirrelCommand(["--removeShortcut", target], done);
    };

    var squirrelEvent = process.argv[1];
    switch (squirrelEvent) {
        case '--squirrel-install':
            install(application.quit);
            return true;
        case '--squirrel-updated':
            install(application.quit);
            return true;
        case '--squirrel-obsolete':
            application.quit();
            return true;
        case '--squirrel-uninstall':
            uninstall(application.quit);
            return true;
    }
    return false;
};


