const { ipcRenderer } = require('electron');
const fs = require('fs');
const path = require('path');
const url = require('url');

global.isElectronApp = true;
var localAppDataPath = process.env.APPDATA + '/CIR_Offline_App';
//send message from FormIO to Electron
global.sendDataToElectron = () => {
    ipcRenderer.sendToHost()
}

// global.callUpdate = (data) => {
//     callElectronApp('Read');
// }

ipcRenderer.on('AppDataPath', (event, data) => {
    localAppDataPath = data;
})

//send message from webview to webpage
global.callElectronApp = (operation, fileName, imageData) => {
    var retVal = receiveData(operation, fileName, imageData);
    return retVal // returns "fromMainProcess"
}

//var ElectronProxy= {
//    RunInspectTool:function (){
//        ipcRenderer.send('run-inspect-tool')
//    }
//};

//global.electronProxy=ElectronProxy;

global.clearCache = () => {
    ipcRenderer.send('clear-cache')
}

function receiveData(operation, fileName, imageData) {
    ipcRenderer.sendToHost();
    var fs = require("fs");
    var returnValue;
    var obj;
    var filepath = "";
    if (localAppDataPath == undefined || localAppDataPath == "") {
        wait(1000);
    }
    if (operation == "Read" && fileName != undefined && imageData != undefined) {
        try {
            filepath = localAppDataPath + '/' + fileName + '/' + imageData + '.json';
            if (fs.existsSync(filepath)) {
                var imgData = JSON.parse(fs.readFileSync(filepath, 'utf8'));
                returnValue = imgData;
            }
            else {
                returnValue = "This file doesn't exist, cannot fetch";
            }

        } catch (e) {
            console.log('Error:', e.stack);
            returnValue = e.stack;
        }
    }
    else if (operation == "RemoveSyncedImage") {
        const dirPath = localAppDataPath + '/' + fileName;
        filepath = localAppDataPath + '/' + fileName + '/' + imageData + ".json";
        if (fs.existsSync(filepath)) {
            fs.unlinkSync(filepath);
            var files = fs.readdirSync(dirPath);
            if (!files.length) {
                fs.rmdirSync(dirPath);
            }
            returnValue = "Synced File succesfully removed from local folder"
        }
        else {
            returnValue = "This file doesn't exist, cannot fetch";
        }
    }
    else if (operation == "Write") {
        filepath = localAppDataPath + "/" + fileName;
        if (!fs.existsSync(filepath)) {
            fs.mkdirSync(filepath);
        }
        for (var i = 0; i < imageData.length; i++) {
            try {
                var imgData = JSON.stringify(imageData[i]);
                filepath = localAppDataPath + "/" + fileName + "/" + imageData[i].imageId + ".json";
                var fd = fs.openSync(filepath, 'w');
                fs.writeFileSync(fd, imgData);
                fs.closeSync(fd);
                returnValue = "Data saved successfully";
            } catch (e) {
                console.log('Error:', e.stack);
                returnValue = e.stack;
            }
        }
    }
    return returnValue;
}

function GetFilesList(dir, filelist) {
    var fs = fs || require('fs'),
        files = fs.readdirSync(dir);
    filelist = filelist || [];
    files.forEach(function (file) {
        var path = dir + '/' + file;
        if (fs.existsSync(path)) {
            var imgData = JSON.parse(fs.readFileSync(path, 'utf8'));
            imgData.imageId = file.split('.')[0];
            filelist.push(imgData);
        }
    });
    return filelist;
}

function wait(ms) {
    var start = new Date().getTime();
    var end = start;
    while (end < start + ms) {
        end = new Date().getTime();
    }
}
