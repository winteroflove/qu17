//Examine the browser
var userAgent = navigator.userAgent.toLowerCase();
var is_saf    = ((userAgent.indexOf('applewebkit') != -1) || (navigator.vendor == 'Apple Computer, Inc.'));
var is_moz    = ((navigator.product == 'Gecko') && (!is_saf));
var httphost  = document.location.host;
/*
function $(objID) {
return document.getElementById(objID)
}

function $f(objName) {
return document.getElementsByName(objName)[0]
}*/

function strencode (str) { 
str=encodeURIComponent(str); 
if (is_moz) str=str.replace(/%0A/g, "%0D%0A"); //In IE, a new line is encoded as \r\n, while in Mozilla it's \n 
return str; 
} 

//ajax组件
var ajax = new Object();
ajax.$x = function(url,onload,onerror,stateArray,method,sendData){
 this.url = url;
 this.req = null;
 this.sendData = (!sendData)?null:sendData;
 this.onload = onload;
 this.onerror = (onerror) ? onerror : this.defaultError;
 this.stateNum = (stateArray) ? stateArray : false;
 this.loadXMLDoc(url,method);
}
ajax.$x.prototype = {
 loadXMLDoc:function(url,method){
  if(window.XMLHttpRequest){
   this.req = new XMLHttpRequest();
   if(this.req.overrideMimeType){
     this.req.overrideMimeType('text/xml');
   }
  }else if(window.ActiveXObject){
   try{
    this.req = new ActiveXObject("Msxml3.XMLHTTP");
   }catch(e){
    try{
     this.req = new ActiveXObject("Msxml2.XMLHTTP");
    }catch(e){
     try{
      this.req = new ActiveXObject("Microsoft.XMLHTTP");
     }catch(e){}
    }
   }
  }
  if(this.req){
   try{
    var loader = this;
    var contentType = null;
    this.req.onreadystatechange = function(){
     loader.onReadyState.call(loader)
    }   

	 if (!method){method="GET";}
	 if (method=="POST"){contentType='application/x-www-form-urlencoded';}
    this.req.open(method,url,true);
        //alert(contentType);
    if (contentType){
        this.req.setRequestHeader('Content-Type', contentType);
    }    
    this.req.send(this.sendData);
   }catch(err){
    this.onerror.call(this);
   }
  }
 },
 onReadyState:function(){
  var req = this.req;
  var ready = req.readyState;
  if(this.stateNum && ready >= 1 && ready <= 3){
   this.stateNum[ready-1].call(this);
  }else if(ready == 4){
   var httpStatus = req.status;
   if(httpStatus == 200 || httpStatus == 0){
    this.onload.call(this);
   }else{
    this.onerror.call(this);
   }
  }
 },
 defaultError:function(){
//  alert("数据连接错误!"
//   + "\n\nreadyState: " + this.req.readyState
//   + "\nstatus: " + this.req.status
//   + "\nheafers: " + this.req.getAllResponseHeaders()
//   )
 }
}

	function deal_tag(){
		var reqText = this.req.responseText;
		$("relate_tags").innerHTML = reqText;
	}	
	

	