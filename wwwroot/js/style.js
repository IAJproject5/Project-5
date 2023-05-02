function hexAdd(a, b) {
	let r1 = parseInt(a.slice(1, 3), 16);
	let g1 = parseInt(a.slice(3, 5), 16);
	let b1 = parseInt(a.slice(5, 7), 16);
	let r2 = parseInt(b.slice(1, 3), 16);
	let g2 = parseInt(b.slice(3, 5), 16);
	let b2 = parseInt(b.slice(5, 7), 16);
	return (rgbCombine(r1 + r2, g1 + g2, b1 + b2));
}
function hexSub(a, b) {
	let r1 = parseInt(a.slice(1, 3), 16);
	let g1 = parseInt(a.slice(3, 5), 16);
	let b1 = parseInt(a.slice(5, 7), 16);
	let r2 = parseInt(b.slice(1, 3), 16);
	let g2 = parseInt(b.slice(3, 5), 16);
	let b2 = parseInt(b.slice(5, 7), 16);
	r1 -= r2;
	g1 -= g2;
	b1 -= b2;
	if (r1 < 0) { r1 = 0 }
	if (r1 > 255) { r1 = 255 }
	if (g1 < 0) { g1 = 0 }
	if (g1 > 255) { g1 = 255 }
	if (b1 < 0) { b1 = 0 }
	if (b1 > 255) { b1 = 255 }
	return (rgbCombine(r1, g1, b1));
}
function hexText(a) {
	let r1 = parseInt(a.slice(1, 3), 16);
	let g1 = parseInt(a.slice(3, 5), 16);
	let b1 = parseInt(a.slice(5, 7), 16);
	if ((r1 + g1 + b1) > 382) {
		return ('#000000')
	} else {
		return ('#FFFFFF')
	}
}
function hexShade(a, b) {
	let r1 = parseInt(a.slice(1, 3), 16);
	let g1 = parseInt(a.slice(3, 5), 16);
	let b1 = parseInt(a.slice(5, 7), 16);
	let r2 = parseInt(a.slice(1, 3), 16);
	let g2 = parseInt(a.slice(3, 5), 16);
	let b2 = parseInt(a.slice(5, 7), 16);
	let diff = 40;
	if ((r2 + g2 + b2) > 382) {
		r1 -= diff;
		g1 -= diff;
		b1 -= diff;
	} else {
		r1 += diff;
		g1 += diff;
		b1 += diff;
	}
	if (r1 < 0) { r1 = 0 }
	if (r1 > 255) { r1 = 255 }
	if (g1 < 0) { g1 = 0 }
	if (g1 > 255) { g1 = 255 }
	if (b1 < 0) { b1 = 0 }
	if (b1 > 255) { b1 = 255 }
	return (rgbCombine(r1, g1, b1));
}
function hexBright(a) {
	let r1 = parseInt(a.slice(1, 3), 16);
	let g1 = parseInt(a.slice(3, 5), 16);
	let b1 = parseInt(a.slice(5, 7), 16);
	let r2 = parseInt(a.slice(1, 3), 16);
	let g2 = parseInt(a.slice(3, 5), 16);
	let b2 = parseInt(a.slice(5, 7), 16);
	let diff = 40;
	if ((r2 + g2 + b2) < 382) {
		r1 -= diff;
		g1 -= diff;
		b1 -= diff;
	} else {
		r1 += diff;
		g1 += diff;
		b1 += diff;
	}
	if (r1 < 0) { r1 = 0 }
	if (r1 > 255) { r1 = 255 }
	if (g1 < 0) { g1 = 0 }
	if (g1 > 255) { g1 = 255 }
	if (b1 < 0) { b1 = 0 }
	if (b1 > 255) { b1 = 255 }
	return (rgbCombine(r1, g1, b1));
}
function hexAvg(a, b) {
	let r1 = parseInt(a.slice(1, 3), 16);
	let g1 = parseInt(a.slice(3, 5), 16);
	let b1 = parseInt(a.slice(5, 7), 16);
	let r2 = parseInt(b.slice(1, 3), 16);
	let g2 = parseInt(b.slice(3, 5), 16);
	let b2 = parseInt(b.slice(5, 7), 16);
	return (rgbCombine(Math.floor((r1 + r2) / 2), Math.floor((g1 + g2) / 2), Math.floor((b1 + b2) / 2)));
}

let white = false;
let black = false;
let red = false;
let green = false;
let blue = false;
let yellow = false;
let cyan = false;
let purple = false;
async function rainbows() {
	//black, purple, blue, cyan, green, yellow, red, pink, white, black

	//225 107 148 pink
	let a = ($("#colors").val())
	let r = parseInt(a.slice(1, 3), 16);
	let g = parseInt(a.slice(3, 5), 16);
	let b = parseInt(a.slice(5, 7), 16);
	if ((r == 255) && (g == 255) && (b == 255)) {
		white = true;
		black = false;
		red = false;
		green = false;
		blue = false;
		yellow = false;
		cyan = false;
		purple = false;
	}
	if ((r == 0) && (g == 0) && (b == 0)) {
		black = true;
		white = false;
		red = false;
		green = false;
		blue = false;
		yellow = false;
		cyan = false;
		purple = false;
	}
	if ((r == 255) && (g == 0) && (b == 0)) {
		red = true;
		white = false;
		black = false;
		green = false;
		blue = false;
		yellow = false;
		cyan = false;
		purple = false;
	}
	if ((r == 0) && (g == 255) && (b == 0)) {
		green = true;
		white = false;
		black = false;
		red = false;
		blue = false;
		yellow = false;
		cyan = false;
		purple = false;
	}
	if ((r == 0) && (g == 0) && (b == 255)) {
		blue = true;
		white = false;
		black = false;
		red = false;
		green = false;
		yellow = false;
		cyan = false;
		purple = false;
	}
	if ((r == 255) && (g == 255) && (b == 0)) {
		yellow = true;
		white = false;
		black = false;
		red = false;
		green = false;
		blue = false;
		cyan = false;
		purple = false;
	}
	if ((r == 0) && (g == 255) && (b == 255)) {
		cyan = true;
		white = false;
		black = false;
		red = false;
		green = false;
		blue = false;
		yellow = false;
		purple = false;
	}
	if ((r == 255) && (g == 0) && (b == 255)) {
		purple = true;
		white = false;
		black = false;
		red = false;
		green = false;
		blue = false;
		yellow = false;
		cyan = false;
	}
	if (black) {
		b += 1;
		r += 1;
	}
	if (purple) {
		r -= 1;
	}
	if (blue) {
		g += 1;
	}
	if (cyan) {
		b -= 1;
	}
	if (green) {
		r += 1;
	}
	if (yellow) {
		g -= 1;
	}
	if (red) {
		g += 1;
		b += 1;
	}
	if (white) {
		r -= 1;
		g -= 1;
		b -= 1;
	}

	let result = rgbCombine(r, g, b);
	document.getElementById("colors").value = result;
	changeColor();
}
async function r() {
	if (document.getElementById("rainbow").checked) {
		delayTime = (100 - (document.getElementById("rainbowSpeed").value)) * 5;
		setTimeout(r, delayTime);
		rainbows();
	}
}
function rgbCombine(r, g, b) {
	let x = r.toString(16);
	let y = g.toString(16);
	let z = b.toString(16);
	if (x.length == 1) {
		x = "0" + x;
	}
	if (y.length == 1) {
		y = "0" + y;
	}
	if (z.length == 1) {
		z = "0" + z;
	}
	return ("#" + x + y + z);
}

//black, purple, blue, cyan, green, yellow, red, pink, white, black

function changeColor() {
	if (document.getElementById("colorCheck").checked) {
		let colorA = ($("#colors").val());
		let colorB = hexShade(colorA, colorA);
		let colorC = (hexSub('#DDDDDD', colorA));
		let colorD = hexShade(colorB, colorA);
		let colorE = hexBright(colorA, colorA);
		let colorT = hexText(colorA);
		$("body, h2, div, .active, a, showing").css("color", colorT);
		$("em").css("color", (hexText(colorT)));
		$(".grid-item, #accordion, .accord-collapsed, .accord-content").css('backgroundColor', colorA).css("border", "1px solid" + colorT);
		$(".schedule-year-block").css('backgroundColor', colorB);
		$("body").css("backgroundColor", colorA);
		$("header").css("background-image", "linear-gradient(to right, " + colorT + " , " + colorA + ")");
		$("button,input").css("backgroundColor", colorD).css("background-image", "none").css("color", hexText(colorD)).css("border", "1px solid" + colorE);
		basicB = "none";
		basicC = "none";
		$(".section-header, .accord-header, .track").css("backgroundColor", colorB);
		$(".active, select, .accord-active, .accord-collapsed:active").css("background-color", colorD).css("border", "1px solid" + colorE).css("color", hexText(colorD))
		$("header").css("border", "1px solid" + colorE)
		hoverB = "linear-gradient(to right, " + colorA + ", " + colorD + ")"
		hoverC = "linear-gradient(to right, " + colorD + ", " + colorD + ")"
		$(".section-header").css("backgroundColor", colorB);
		$(".active").css("background-color", colorD).css("border", "1px solid" + colorE).css("color", hexText(colorD))
		$("header").css("border", "1px solid" + colorE);
		$("#accordion").css("background-color", colorD);
		$("#accordion .ui-accordion-content").css("background-color", colorB);
		$(".ui-accordion-header-active").css("background-color", colorD);
		$(".ui-accordion-header-collapsed").css("background-color", colorA).css("background-image", "none");
		$(".ui-accordion-header-collapsed:hover").css("background-color", colorD);
		$(".ui-accordion-header-collapsed:active").css("background-color", colorE).css("color", hexText(colorD));
		hoverB = "linear-gradient(to right, " + colorA + ", " + colorD + ")";
	} else {
		$("body, h2, div, .active, a, select").css("color", "black");
		$("em").css("color", "blue");
		$("button").css("background-image", "linear-gradient(to right, rgb(220, 190, 50), rgb(255, 250, 30))").css("color", "black").css("border", "2px solid black").css("border-radius", "4px");
		basicB = "linear-gradient(to right, rgb(220, 190, 50), rgb(255, 250, 30))";
		basicC = "linear-gradient(to right, rgb(220, 190, 50), rgb(220, 190, 50))";
		$(".section-header").css("color", "2779aa").css("backgroundColor", "rgb(200, 220, 255)");
		$("#title").css("color", "blue");
		$(".schedule-year-block").css("background-color", "rgb(238, 238, 238)").css("border", "1px solid rgb(200,200,200)");
		$(".active").css("background-color", "rgb(200, 220, 255)").css("color", "#2779aa").css("border", "1px solid #2779aa")
		$(".grid-item").css("background", "white").css("border", "1px solid lightblue");
		$("header").css("border", "1px solid blue").css("background-image", "linear-gradient(to right, rgb(200, 220, 255), white)")
		$("body, select").css("backgroundColor", "white");
		$("h2").css("color", "#2779aa");
		$("input").css("background-image", "").css("backgroundColor", "white").css("color", "black").css("border", "2px groove lightgrey").css("border-radius", "3px");
		hoverB = "linear-gradient(to right, rgb(250, 230, 50), rgb(255, 255, 255))"
		hoverC = "linear-gradient(to right, rgb(250, 230, 50), rgb(250, 230, 50))"
		$("#accordion").css("background-color", "rgb(220, 230, 255)");
		$(".ui-accordion-content").css("background-color", "rgb(200, 220, 255)");
		$(".ui-accordion-header-active").css("background-color", "rgb(255, 250, 30)").css("color", "black");;
		$(".ui-accordion-header-collapsed").css("background-color", "rgb(220, 190, 50)");
		$(".ui-accordion-header-collapsed:hover").css("background-color", "rgb(255, 255, 55)");
		$(".ui-accordion-header-collapsed:active").css("background-color", "rgb(255, 255, 255)");
		hoverB = "linear-gradient(to right, rgb(250, 230, 50), rgb(255, 255, 255))";
	}
}


let colorA = '#000000';
let colorB = '#0000FF';
let colorC = '#FFFFFF';
let hoverB = "linear-gradient(to right, rgb(250, 230, 50), rgb(255, 255, 255))";
let basicB = "linear-gradient(to right, rgb(220, 190, 50), rgb(255, 250, 30))";
let basicC = "linear-gradient(to right, rgb(220, 190, 50), rgb(220, 190, 50))";
let hoverC = "linear-gradient(to right, rgb(250, 230, 50), rgb(250, 230, 50))"
let delayTime = 1000000;
let pageScheduleContainer;
let pageScheduleHeader;
let currentCatalog;

function styleInit() {
	if (window.matchMedia && window.matchMedia('(prefers-color-scheme: dark)').matches) {
		document.getElementById("colorCheck").setAttribute("checked", "");
	}

	$("button").mouseover(function () {
		//$(this).css("background-image", hoverB);
		changeColor()
	}).mouseout(function () {
		//$(this).css("background-image", basicB);
		changeColor()
	});
	$("#accordion .ui-accordion-header-collapsed").mouseover(function () {
		//$(this).css("background-image", hoverC);
		changeColor()
	}).mouseout(function () {
		//$(this).css("background-image", basicC);
		changeColor()
	});


	document.getElementById("rainbow").addEventListener("click", r);
}

function styleLateInit() {
	//document.getElementById("colors").addEventListener("input", changeColor);
	//document.getElementById("colorCheck").addEventListener("change", changeColor);
	//klisten0(document.getElementById("year"), "http://judah.cedarville.edu/~gallaghd/ymm/ymmdb.php?fmt=xml");
	//document.getElementById("year").addEventListener("change", klisten1);
	//document.getElementById("make").addEventListener("change", klisten2);
}
