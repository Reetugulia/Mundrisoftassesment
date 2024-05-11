
$(document).ready(function () {
	$("button").click(function () {
		$.get("https://api.openweathermap.org/data/2.5/weather?Cleveland&APPID=58504e2255e9b3cdbd80fa4cb6887c60&units=imperal", function (response) {
			$("weather").text(JSON.stringify(response))
		})
	});
});