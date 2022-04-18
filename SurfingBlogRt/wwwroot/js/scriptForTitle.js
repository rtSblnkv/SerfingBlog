document.ready = initAll;
var xhr = false, x, allSubs, elements, ps;
function initAll() {
  elements = document.querySelectorAll(".name-place");
  for (let i = 0; i < elements.length; i++)
    elements[i].onclick = displayTitle;
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
    xhr.onreadystatechange = setTitlesArray;
    xhr.open("GET", "firmCatalog.xml", true);
    xhr.send();
  }
  /*else
    alert("Error 1");*/
}
function setTitlesArray() {
  if (xhr.readyState == 4) {
    if (xhr.status == 200) {
      if (xhr.responseXML)
        allSubs = xhr.responseXML.getElementsByTagName("Firm");
      /*else
        alert("Error 2 " + xhr.status);*/
    }
  }
}
function displayTitle() {
  var i = parseInt(this.getAttribute("value"));
  document.getElementById("show" + i).innerHTML = allSubs[i - 1].getElementsByTagName("TITLE")[0].childNodes[0].nodeValue;
}