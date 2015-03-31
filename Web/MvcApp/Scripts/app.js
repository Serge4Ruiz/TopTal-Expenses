(function () {
	var app = angular.module('member', [])

	app.controller('MemberController', ['$http', function ($http) {
		var member = this;
		var userName = sessionStorage.getItem('userName');
		$http.get('http://localhost:54000/api/member/' + userName).success(function(data) {
			member.expenses = data;
		});
	}]);
})();
