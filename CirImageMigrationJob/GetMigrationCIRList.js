
/*				  function getMigrationCIRList() {
                            var context = getContext();
                            var collection = getContext().getCollection();
                            var response = context.getResponse();

                            var latestCirIdQuery = "SELECT  * FROM  c WHERE c.templateVersion=0.8";

                   var isSuccessful= collection.queryDocuments(collection.getSelfLink(), latestCirIdQuery,
                                function(err, documents, responseOptions) {
                                    if (err) throw err;
                                    if (!documents|| documents.length < 1)
                                    {
                                        response.setBody("Unable to find Cir list.");
                                    }
									else
									{
										var currentCirId = documents;								
                                        response.setBody(JSON.stringify(documents));                                   
									}

                           
                        }); if (!isSuccessful) throw "Request to get Cir list failed.";
}

 function getCIRMigrationListRange() {
                            var context = getContext();    var response = context.getResponse();
                            //Cir Template version
                            var templateVersion=0.8;

                            //Provide range in decrement order
                            var startingPoint= 600001; var endingPoint=400000;
                            //Add anyother where clause need to be enter
                             var otherWhereClause='';

if(startingPoint>0 &&endingPoint>=0 && templateVersion>0)
							response.setBody(startingPoint+"#"+endingPoint+"#"+templateVersion+"#"+otherWhereClause);
                            else
                            response.setBody("0#0#0#");
                }

*/