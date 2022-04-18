window.onload = initAll;
var xhr = false, img, link, p, h2;
function initAll() {
    document.querySelector(".more_button").onclick = showContent;
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
		xhr.onreadystatechange = func;
		xhr.open("GET", "main.html");
		xhr.send(null);
	}
	else
		alert("Error 1");
}
function func() {
	if (xhr.readyState == 4) {
		if (xhr.status == 200) {
			img = "images/interview.jpeg";
			link = "main.html";
			p = "Каждый соискатель сталкивается с тем, что ему необходимо прийти на собеседование. Задача на первый взгляд проста — рассказать о себе, ответить на вопросы работодателя, но с другой стороны нужно уметь презентовать себя, рассказать те факты, которые могут приятно удивить рекрутера";
			h2 = "Рассказ о себе на собеседовании";
		}
		else
			alert("Error 2 " + xhr.status);
	}
}
function showContent() {
	var newDiv = document.createElement("div");
    newDiv.className = "article";
    
	var newDiv2 = document.createElement("div");
	newDiv2.className = "image_container";

	var newDiv3 = document.createElement("div");
	newDiv3.className = "article_review";


	var newImg = document.createElement("img");
	newImg.className = "article_img";
    newImg.src = img;
    this.body.appendChild(newImg)

	var newA = document.createElement("a");
	newA.href = link;
	/*var newP = document.createElement("p");
	newP.className = "text";
	newP = "Читать";
	newA.appendChild(newP);*/

	var newA2 = document.createElement("a");
	newA2.href = link;
	/*var newP2 = document.createElement("h2");
	newP2 = h2;
	newA2.appendChild(newP2);
	var newP3 = document.createElement("p");
	newP3=p;
	newDiv3.appendChild(newP3);*/
}
