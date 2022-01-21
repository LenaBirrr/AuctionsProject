
$("#UserId").selectize({
	plugins: ["remove_button"],
	valueField: "id",
	labelField: "id",
	searchField: "id",
	placeholder: "Выберите пользователя",
	options: [],
	persist: false,
	create: false,

	load: function (query, callback) {
		if (!query.length) {
			return callback();
		}

		$.get("/api/User/find/" + query,
			function (data) {
				if (data.length > 0) {
					$("#UserId option").remove();

					for (var i = 0; i < data.length; i++) {
						$("#UserId").append(
							"<option value=\"" + data[i].id + "\"></option>");
					}

					callback(data);
				}
			}, "json");
	}
});