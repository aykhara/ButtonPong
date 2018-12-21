/*
# Access granted under MIT Open Source License: https://en.wikipedia.org/wiki/MIT_License
#
# Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated 
# documentation files (the "Software"), to deal in the Software without restriction, including without limitation 
# the rights to use, copy, modify, merge, publish, distribute, sublicense, # and/or sell copies of the Software, 
# and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
#
# The above copyright notice and this permission notice shall be included in all copies or substantial portions 
# of the Software.
#
# THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED 
# TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL 
# THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF 
# CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER 
# DEALINGS IN THE SOFTWARE.
#
# Created by: Brent Stineman
#
# Description: This is an HTTP triggered Azure function to reset all game info, used for debug purposes
#    For more info see: https://github.com/brentstineman/ButtonPong 
#
#
# Modifications
# 2018/03/03 : Initial publication
#
*/
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text;
using System.Net;

namespace CloudAPI
{
    public static class GetStatus
    {
        [FunctionName("GetGameStatus")]
        public async static Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Function, "get", Route = "game")]HttpRequestMessage req, TraceWriter log)
        {
            log.Info("RestartGame processed a request.");

            HttpResponseMessage rtnResponse = null;

            GameStateManager gameState = new GameStateManager(); // get game state

            rtnResponse = req.CreateResponse(HttpStatusCode.OK);
            rtnResponse.Content = new StringContent(JsonConvert.SerializeObject(gameState.GameState, Formatting.Indented), Encoding.UTF8, "application/json");

            return rtnResponse;
        }
    }
}
