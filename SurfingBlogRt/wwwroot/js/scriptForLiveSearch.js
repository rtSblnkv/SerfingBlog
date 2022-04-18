window.onload = initAll;
var xhr = false;
var subsArray = new Array();
function initAll() {
	document.getElementById("searchField").onkeyup = searchSuggest;
	if (window.XMLHttpRequest) 
		xhr = new XMLHttpRequest();
	else {
		if (window.ActiveXObject) {
			try {
				xhr = new ActiveXObject("Microsoft.XMLHTTP");
			}
			catch (e) { }
		}
	}
	if (xhr) {
		xhr.onreadystatechange = setSubsArray;
		xhr.open("GET", "russia.xml", true);
		xhr.send(null);
	}
	/*else
		alert("Error 1");*/
}
function setSubsArray() {
	if (xhr.readyState == 4) {
		if (xhr.status == 200) {
			if (xhr.responseXML) {
				var allSubs = xhr.responseXML.getElementsByTagName("subject_of_federation");
				for (var i=0; i<allSubs.length; i++)
					subsArray[i] = allSubs[i].getElementsByTagName("name")[0].firstChild;
			}
		}
		/*else
			alert("Error 2 " + xhr.status);*/
	}
}
function searchSuggest() {
	var str = document.getElementById("searchField").value;
	document.getElementById("searchField").className = "";
	if (str != "") {
		document.getElementById("popups").innerHTML = "";
		for (var i=0; i<subsArray.length; i++) {
			var thisSub = subsArray[i].nodeValue;
			if (thisSub.toLowerCase().indexOf(str.toLowerCase()) == 0) {
				var tempDiv = document.createElement("div");
				tempDiv.innerHTML = thisSub;
				tempDiv.onclick = makeChoice;
				tempDiv.className = "suggestions";
				document.getElementById("popups").appendChild(tempDiv);
			}
		}
		var foundCt = document.getElementById("popups").childNodes.length;
		if (foundCt == 0)
			document.getElementById("searchField").className = "error";
		if (foundCt == 1) {
			document.getElementById("searchField").value = document.getElementById("popups").firstChild.innerHTML;
			document.getElementById("popups").innerHTML = "";
		}
	}
}
function makeChoice(evt) {
	var thisDiv = (evt) ? evt.target : window.event.srcElement;
	document.getElementById("searchField").value = thisDiv.innerHTML;
	document.getElementById("popups").innerHTML = "";
}
