/*
 * jQuery UI Accordion 1.8.17
 *
 * Copyright 2011, AUTHORS.txt (http://jqueryui.com/about)
 * Dual licensed under the MIT or GPL Version 2 licenses.
 * http://jquery.org/license
 *
 * http://docs.jquery.com/UI/Accordion
 *
 * Depends:
 *	jquery.ui.core.js
 *	jquery.ui.widget.js
 */

//let currentPlan = new Plan("", 0, "", "", );

let currentHighestYear = new Date().getFullYear() - 1;
function capitalizeFirstLetter(string) {
    return string.charAt(0).toUpperCase() + string.slice(1);
}

function Plan(name, year, major, studentName, currentSemester, courses) {
	this.name = name;
	this.year = year;
	this.major = major;
	this.studentName = studentName;
	this.currentSemester = currentSemester;
	this.courses = courses;
};

function Course(id, name, credits, term, year) {
	this.id = id;
	this.name = name;
	this.credits = credits;
	this.term = term;
	this.year = year;
};

function Year(year, terms = []) {
	this.year = year;
	this.terms = terms;
};

function Term(semester, courses = []) {
	this.semester = semester;
	this.courses = courses;
};

function planToYears(plan) {
	let years = [];
	let yearIndex = -1;
	let termIndex = -1;
	let yearFound = false;
	let termFound = false;
	let first = true;
	let planYear = -1;
	for (let k = 0; k < plan.courses.length; k++) {
		if (plan.courses[k].term === "Spring" || plan.courses[k].term === "Summer") {
			planYear = plan.courses[k].year - 1;
		}
		else {
			planYear = plan.courses[k].year;
		}
		for (let i = 0; i < years.length; i++) {
			if (planYear == years[i].year) {
				yearFound = true;
				yearIndex = i;
			}
		}
		if (!yearFound) {
			years.push(new Year(planYear));
			yearIndex = years.length - 1;
			years[yearIndex].terms.push(new Term("Fall"));
			years[yearIndex].terms.push(new Term("Spring"));
			years[yearIndex].terms.push(new Term("Summer"));
		}
		for (let i = 0; i < years[yearIndex].terms.length; i++) {
			if (plan.courses[k].term == years[yearIndex].terms[i].semester) {
				termFound = true;
				termIndex = i;
			}
		}
		if (!termFound) {
			years[yearIndex].terms.push(new Term(plan.courses[k].term));
			termIndex = years[yearIndex].terms.length - 1;
		}
		years[yearIndex].terms[termIndex].courses.push(plan.courses[k]);
		yearFound = false;
		termFound = false;
	}
	return years.sort((a, b) => (a.year > b.year) ? 1 : (a.year < b.year) ? -1 : 0);
}

function sumCreditHours(courses) {
	sum = 0;
	for (let i = 0; i < courses.length; i++) {
		sum += courses[i].credits;
	}
	return sum;
}

function generateScheduleHTML(plan) {
	let returnHTML = "";
	let yearsFormatted = planToYears(plan);
	let present = false;
	let outputYear;
	for (let i = 0; i < yearsFormatted.length; i++) {
		year = yearsFormatted[i];
		if (year.year > currentHighestYear) {
			currentHighestYear = year.year
		}
		for (let k = 0; k < year.terms.length; k++) {
			term = year.terms[k];
			if (term.semester === "Spring" || term.semester === "Summer") {
				outputYear = year.year + 1;
			}
			else {
				outputYear = year.year;
			}
			if (present == false) {
				returnHTML +=
					"<div id='" + term.semester + "," + outputYear + "' ondragover='onYearDragOver(event)' ondrop='onCourseDrop(event, this)' class=\"schedule-year-block\"><span class=\"semester-title\">" +
					term.semester + " " + outputYear +
					"</span><span class=\"semester-hours\">Hours: " +
					sumCreditHours(term.courses) + "</span><br><ul class=\"course-list\">";
				if (plan.currentSemester == term.semester + " " + outputYear) {
					present = true;
				}
			}
			else {
				returnHTML +=
					"<div class=\"schedule-year-block active\"><span class=\"semester-title\">" +
					term.semester + " " + outputYear +
					"</span><span class=\"semester-hours\">Hours: " +
					sumCreditHours(term.courses) + "</span><br><ul class=\"course-list\">";
			}
			for (let j = 0; j < term.courses.length; j++) {
				course = term.courses[j];
				if (course.id != "") {
					returnHTML += "<li ondragstart='dragCourse(event)' draggable='true' class=\"course\" id='" + course.id + "'>" + course.id + " " + course.name +
						"<button onclick='removeCourse(this)'>X</button></li>";
				}
			}
			returnHTML += "</ul></div>";
		}
	}
	return returnHTML;
}

function savePlan(event) {
	console.log(JSON.stringify(currentPlan));
	return;
	xhrReq = new XMLHttpRequest();
	xhrReq.addEventListener("load", planSaveHandler);
	xhrReq.responseType = "";
	xhrReq.open("PUT", "/plan/" + document.getElementById("planSelect").value);
	xhrReq.send(JSON.stringify(currentPlan));
}

function addYear(event) {
	currentHighestYear++;
	currentPlan.courses.push(new Course("", "", 0, "Fall", currentHighestYear));
	pageScheduleContainer.innerHTML = generateScheduleHTML(currentPlan);
	pageScheduleHeader.innerHTML = generateScheduleHeader(currentPlan);
}

function removeCourse(event) {
	var target = event;
	var parent = target.parentElement;
	console.log(target.innerHTML);
	if (target.innerHTML != "X") {
		return;
	}
	console.log(parent.id);
	for (let i = 0; i < currentPlan.courses.length; i++) {
		if (currentPlan.courses[i].id == parent.id/*ID of course with X pressed*/) {
			currentPlan.courses.splice(i, 1);
		}
	}
	pageScheduleContainer.innerHTML = generateScheduleHTML(currentPlan);
	pageScheduleHeader.innerHTML = generateScheduleHeader(currentPlan);
	xhrReq = new XMLHttpRequest();
	xhrReq.addEventListener("load", loadRequirements);
	xhrReq.responseType = "json";
	xhrReq.open("GET", "/plan/" + document.getElementById("planSelect").value + "/requirements");
	xhrReq.send();
	return;
}

function onYearDragOver(event) {
	event.preventDefault();
}

function onCourseDrop(event, caller) {
	if (event.currentTarget.classList.contains("schedule-year-block")) {
		console.log(event.currentTarget.id);
		event.preventDefault();
		console.log("Dropped " + event.dataTransfer.getData("courseInfo"));
		let dropCourseID = event.dataTransfer.getData("courseInfo").split(",")[0];
		for (let i = 0; i < currentPlan.courses.length; i++) {
			if (currentPlan.courses[i].id == dropCourseID) {
				currentPlan.courses.splice(i, 1);
			}
		}
		currentPlan.courses.push(new Course(dropCourseID, currentCatalog.courses[dropCourseID].name, currentCatalog.courses[dropCourseID].credits, event.currentTarget.id.split(",")[0], event.currentTarget.id.split(",")[1]));
		pageScheduleContainer.innerHTML = generateScheduleHTML(currentPlan);
		pageScheduleHeader.innerHTML = generateScheduleHeader(currentPlan);
		xhrReq = new XMLHttpRequest();
		xhrReq.addEventListener("load", loadRequirements);
		xhrReq.responseType = "json";
		xhrReq.open("GET", "/plan/" + document.getElementById("planSelect").value + "/requirements");
		xhrReq.send();
	}
}

function dragCourse(event) {
	let courseInfo = event.target.id.split(" ")[0];
	event.dataTransfer.setData("courseInfo", courseInfo);
}

function dragTableCourse(event) {

}

function generateScheduleHeader(plan) {
	let returnHTML = "";
	returnHTML = "<h2>Academic Plan: " + plan.name + "</h2><span>" + sumCreditHours(plan.courses) + " Credit Hours</span>";
	return returnHTML;
}

function externalPlanHandler() {
	if (this.status === 200) {
		let returnPlan = new Plan("John Smith's Plan", 0, "", "John Smith", "", []);
		let externalPlan = this.response.plan;
		console.log(this.status);
		currentCatalog = this.response.catalog;
		let currentYear;
		returnPlan.name = externalPlan.name;
		returnPlan.year = externalPlan.currYear;
		returnPlan.major = externalPlan.major;
		returnPlan.currentSemester = "" + externalPlan.currTerm + " " + externalPlan.currYear;
		returnPlan.studentName = externalPlan.student;
		let currentCourse;

		for (let courseKey in externalPlan.courses) {
			//console.log(courseKey)
			currentCourse = externalPlan.courses[courseKey];
			if (courseKey != "") {
				returnPlan.courses.push(new Course(
					currentCourse.id,
					currentCatalog.courses[courseKey].name,
					currentCatalog.courses[courseKey].credits,
					capitalizeFirstLetter(currentCourse.term),
					currentCourse.year)
				);
				//console.log(Object.getOwnPropertyNames(currentCatalog.courses[courseKey]))
			}
		}
		currentPlan = returnPlan;
		pageScheduleContainer.innerHTML = generateScheduleHTML(currentPlan);
		pageScheduleHeader.innerHTML = generateScheduleHeader(currentPlan);
		//document.getElementById("student").innerHTML = "<strong>Student: </strong>" + externalPlan.student;
		document.getElementById("catalog").innerHTML = "<strong>Catalog: </strong><var>" + externalPlan.currYear + "</var>";
		document.getElementById("major").innerHTML = "<strong>Major: </strong><var>" + externalPlan.major + "</var>";
		document.getElementById("minor").innerHTML = "<strong>Minor: </strong><var>" + externalPlan.minor + "</var>";

		for (const property in (currentCatalog.courses)) {
			$("tbody").append("<tr ondragstart='dragCourse(event)' draggable='true' id='" + property + "'><td>"+property+"</td><td>"+currentCatalog.courses[property].name+"</td><td>"+currentCatalog.courses[property].credits+"</td></tr>")
		}
		searchCourses();
	}
}

function isCourseOnPlan(id) {
	var $courses = $(".course");
	for(let i = 0; i < $courses.length; i++) {
		if($courses.eq(i).html().split(" ")[0] == id) {
			return true;
		} else {
			//console.log(id);
		}
	}
	return false;
}

function loadRequirements() {
	if (this.status == 200) {
		//parser = new DOMParser();
		//let requirements = parser.parseFromString(this,"text/xml");
		//console.log("LoadRequirements:"+requirements);

		let requirements = this.response.categories;
		console.log(this.response);

		let currentCourseName = "";

		// Load Core Classes
		let coreHTML = "<p>";
		//console.log(currentCatalog);
		if (requirements.Core !== undefined) {
			for (let course in requirements.Core.courses) {
				if (isCourseOnPlan(requirements.Core.courses[course])) {
					coreHTML += "<img src='/images/checkmark.png' width=10 height=10> ";
				} else {
					coreHTML += "<img src='/images/x-mark.png' width=10 height=10> ";
				}
				currentCourseName = currentCatalog.courses[requirements.Core.courses[course]].name;
				coreHTML += "<span ondragstart='dragCourse(event)' draggable='true' id='" + requirements.Core.courses[course] + "'>" + requirements.Core.courses[course] + " " + currentCourseName + "</span><br>";
			}
		}
		$(".core").html(coreHTML + "</p>");

		// Load Track (Elective) Classes
		let trackHTML = "<p>";
		if (requirements.Electives !== undefined) {
			for (let course in requirements.Electives.courses) {
				if (isCourseOnPlan(requirements.Electives.courses[course])) {
					trackHTML += "<img src='/images/checkmark.png' width=10 height=10> ";
				} else {
					trackHTML += "<img src='/images/x-mark.png' width=10 height=10> ";
				}
				currentCourseName = currentCatalog.courses[requirements.Electives.courses[course]].name;
				trackHTML += "<span ondragstart='dragCourse(event)' draggable='true' id='" + requirements.Electives.courses[course] + "'>" + requirements.Electives.courses[course] + " " + currentCourseName + "</span><br>";
			}
		}
		$(".track").html(trackHTML + "</p>");

		// Load Cognates
		let cognatesHTML = "<p>";
		if (requirements.Cognates !== undefined) {
			for (let course in requirements.Cognates.courses) {
				if (isCourseOnPlan(requirements.Cognates.courses[course])) {
					cognatesHTML += "<img src='/images/checkmark.png' width=10 height=10> ";
				} else {
					cognatesHTML += "<img src='/images/x-mark.png' width=10 height=10> ";
				}
				currentCourseName = currentCatalog.courses[requirements.Cognates.courses[course]].name;
				cognatesHTML += "<span ondragstart='dragCourse(event)' draggable='true' id='" + requirements.Cognates.courses[course] + "'>" + requirements.Cognates.courses[course] + " " + currentCourseName + "</span><br>";
			}
		}
		$(".cognates").html(cognatesHTML + "</p>");

		// Load Gen Eds
		let genEdsHTML = "<p>";
		if (requirements.GenEds !== undefined) {
			for (let course in requirements.GenEds.courses) {
				if (isCourseOnPlan(requirements.GenEds.courses[course])) {
					genEdsHTML += "<img src='/images/checkmark.png' width=10 height=10> ";
				} else {
					genEdsHTML += "<img src='/images/x-mark.png' width=10 height=10> ";
				}
				currentCourseName = currentCatalog.courses[requirements.GenEds.courses[course]].name;
				genEdsHTML += "<span ondragstart='dragCourse(event)' draggable='true' id='" + requirements.GenEds.courses[course] + "'>" + requirements.GenEds.courses[course] + " " + currentCourseName + "</span><br>";
			}
		}
		$(".geneds").html(genEdsHTML + "</p>");
	}
}

function searchCourses() {
	let notValid = /[^\w" "+-]/;
	let amountOfCourses = 0;
	let num = document.getElementById("showing");
	let input = document.getElementById("search").value.toUpperCase();
	let table = document.getElementById("courselist");
	for (let i = 1, cell; cell = table.rows[i]; i++) {
		let t = cell.textContent || cell.innerText;
		if (t.toUpperCase().indexOf(input)>-1){
			cell.style.display="";
			amountOfCourses+=1;
		} else{
			cell.style.display="none";
		}
	}
	num.innerHTML = ("Showing 1 to "+amountOfCourses +" of "+amountOfCourses);
	num.style.color = "black";
	if (amountOfCourses==0){
		num.innerHTML = ("No Classes Found");
		//num.style.color = "blue";
	}
	if (input.match(notValid)){
		num.innerHTML = ("Invalid input");
		//num.style.color = "red";
	}
}


function clearCourses() {
	document.getElementById("search").value = "";
	searchCourses();
}

function init() {
	styleInit();

	let amountOfCourses = document.getElementById("courselist").rows.length-1
	let num = document.getElementById("showing");
	num.innerHTML = ("Showing 1 to "+amountOfCourses +" of "+amountOfCourses);
	if (amountOfCourses==0){
		num.innerHTML = ("No Classes Found");
		//num.style.color = "blue";
	}
	document.getElementById("search").addEventListener("keyup", searchCourses);
	document.getElementById("clear").addEventListener("click", clearCourses);
	//document.getElementById("planSelect").addEventListener("change", this.form.submit());
	document.getElementById("clear").style.cursor = "pointer";
	pageScheduleContainer = document.getElementsByClassName("schedule-container")[0];
	pageScheduleHeader = document.getElementById("schedule-header");

	let xhr = new XMLHttpRequest();
	let xhrReq;

	xhr.addEventListener("load", externalPlanHandler);
	xhr.responseType = "json";
	xhr.open("GET", "/plan/" + document.getElementById("planSelect").value);
	//console.log("Sent request to route!" + " localhost:7019/plan/" + document.getElementById("planSelect").value);
	xhr.onreadystatechange = function () {
		if (xhrReq == undefined) {
			xhrReq = new XMLHttpRequest();
			xhrReq.addEventListener("load", loadRequirements);
			xhrReq.responseType = "json";
			xhrReq.open("GET", "/plan/" + document.getElementById("planSelect").value + "/requirements");
			xhrReq.send();
		}
	}
	xhr.send();

	styleLateInit();
}

function klisten0(doc, addr) {
	var xhttp = new XMLHttpRequest();
	xhttp.onreadystatechange = function() {
	  if (this.readyState == 4 && this.status == 200) {
			parser = new DOMParser();
			xmlDoc = parser.parseFromString(xhttp.responseText,"text/xml");
			let years = xmlDoc.getElementsByTagName("year")
			for (let i = 0; i < years.length; i++) {
				let option = document.createElement("option");
				option.text = years[i].textContent;
				option.value = "car";
				doc.appendChild(option);
			}
		}
	};
	let option = document.createElement("option");
	option.text = " ";
	option.value = "";
	doc.appendChild(option)
	xhttp.open("GET", addr, true);
	xhttp.send();
}

function klisten1() {
	if (!(document.getElementById("year").value=='')){
		document.getElementById("make").disabled=false;

		var xhttp = new XMLHttpRequest();
		xhttp.onreadystatechange = function() {
			if (this.readyState == 4 && this.status == 200) {
			parser = new DOMParser();
			xmlDoc = parser.parseFromString(xhttp.responseText,"text/xml");
			let makes = xmlDoc.getElementsByTagName("make")
				for (let i = 0; i < makes.length; i++) {
					let option = document.createElement("option");
					let vars = makes[i].textContent.split(" ");
					option.text = vars[8].trim();
					option.value = vars[4].trim();
					document.getElementById("make").appendChild(option);
				}
			}
		};
		let option = document.createElement("option");
		option.text = " ";
		option.value = "";
		document.getElementById("make").appendChild(option)
		let t = document.getElementById("year");
		xhttp.open("GET", "http://judah.cedarville.edu/~gallaghd/ymm/ymmdb.php?fmt=xml&year="+t.options[t.selectedIndex].text, true);
		xhttp.send();

	} else {
		clearCars(document.getElementById("make"));
		clearCars(document.getElementById("model"));
		document.getElementById("make").disabled=true;
		document.getElementById("model").disabled=true;
	}
}

function klisten2() {
	if (!(document.getElementById("make").value=='')) {
		document.getElementById("make").disabled=false;
		document.getElementById("model").disabled=false;
		var xhttp = new XMLHttpRequest();
		xhttp.onreadystatechange = function() {
			if (this.readyState == 4 && this.status == 200) {
				parser = new DOMParser();
				xmlDoc = parser.parseFromString(xhttp.responseText,"text/xml");
				let makes = xmlDoc.getElementsByTagName("model")
				for (let i = 0; i < makes.length; i++) {
					let option = document.createElement("option");
					let vars = makes[i].textContent.split(" ");
					option.text = vars[8].trim();
					option.value = vars[4].trim();
					document.getElementById("model").appendChild(option);
				}
			}
		}
		let option = document.createElement("option");
		option.text = " ";
		option.value = "";
		document.getElementById("model").appendChild(option)
		let t = document.getElementById("year");
		let m =document.getElementById("make");
		xhttp.open("GET", "http://judah.cedarville.edu/~gallaghd/ymm/ymmdb.php?fmt=xml&year="+t.options[t.selectedIndex].text+"&make="+m.options[m.selectedIndex].value, true);
		xhttp.send();
	} else {
		clearCars(document.getElementById("model"));
		document.getElementById("model").disabled=true;
	}
}
function clearCars(doc) {
	while (doc.hasChildNodes()){
		doc.removeChild(doc.firstChild);
	}
}

function changePlan(event) {
	let xhr = new XMLHttpRequest();
	let xhrReq;

	xhr.addEventListener("load", externalPlanHandler);
	xhr.responseType = "json";
	xhr.open("GET", "/plan/" + document.getElementById("planSelect").value);
	console.log("Sent request to route!" + " localhost:7019/plan/" + document.getElementById("planSelect").value);
	xhr.onreadystatechange = function () {
		if (xhrReq == undefined) {
			xhrReq = new XMLHttpRequest();
			xhrReq.addEventListener("load", loadRequirements);
			xhrReq.responseType = "json";
			xhrReq.open("GET", "/plan/" + document.getElementById("planSelect").value + "/requirements");
			xhrReq.send();
		}
	}
	xhr.send();
	currentHighestYear = new Date().getFullYear() - 1;
	return;
}

$( function() {
  $( "#accordion" ).accordion({
		active: 1,
		animate: 100,
		heightStyle: "fill",
		activate: function(event, ui) {
			$( "#accordion" ).accordion( "refresh" );
			changeColor();
		},
		beforeActivate: function(event, ui) {
			$( "#accordion" ).accordion( "refresh" );
			changeColor();
		}
	});
} );

window.onresize = function() {
	$( "#accordion" ).accordion( "refresh" );
}

$(document).ready(init);
