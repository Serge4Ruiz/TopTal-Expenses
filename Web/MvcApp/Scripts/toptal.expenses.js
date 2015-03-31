$(document).ready(function () {
	showUserInfo();
});

var register = function () {
	$("#RegistrationError").text('');
	var registrationUrl = "http://localhost:54000/api/account/Register";
	var registrationData = $("#userSignup").serialize();
	var result = $.post(registrationUrl, registrationData).always(function () {
		if (result.status == 200) {
			signin();
		} else {
			$("#RegistrationError").text(result.responseText);
		}
	});
	return false;
};

var signin = function() {
	var tokenUrl = "http://localhost:54000/Token";
	var loginData = $("#userSignup").serialize();
	loginData = loginData + "&grant_type=password";
	var result = $.post(tokenUrl, loginData).always(function () {
		if (result.status == 200) {
			var json = $.parseJSON(result.responseText);
			sessionStorage.setItem('tokenKey', json.access_token);
			sessionStorage.setItem('userName', json.userName);
			window.location = '/Member';
		} else {
			$("#RegistrationError").text(result.responseText);
		}
	});
	return false;
}

var login = function () {
	var tokenUrl = "http://localhost:54000/Token";
	var loginData = $("#userLogin").serialize();
	loginData = loginData + "&grant_type=password";
	var result = $.post(tokenUrl, loginData).always(function () {
		if (result.status == 200) {
			var json = $.parseJSON(result.responseText);
			sessionStorage.setItem('tokenKey', json.access_token)
			sessionStorage.setItem('userName', json.userName);
			window.location = '/Member';
		} else {
			$("#RegistrationError").text(result.responseText);
		}
	});
	return false;
}

var showUserInfo = function () {
	var token = sessionStorage.getItem('tokenKey');
	var userName = sessionStorage.getItem('userName');
	if (token) {
		$("#UserNameDisplay").text(userName);
		$("#UserInfo").show();
		$("#Access").hide();
	} else {
		$("#UserInfo").hide();
		$("#Access").show();
	}
}

var logout = function () {
	sessionStorage.removeItem('tokenKey');
	sessionStorage.removeItem('userName');
	window.location = '/';
}

var addExpense = function () {
	var response = $.ajax(
		);
}

var getHeaders = function () {
	var token = sessionStorage.getItem('tokenKey');
	if (token) {
		return { "Authorization": "Bearer " + token };
	}
}
