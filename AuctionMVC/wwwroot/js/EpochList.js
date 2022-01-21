
$("#EpochId").selectize({
	plugins: ["remove_button"],
	valueField: "id",
	labelField: "name",
	searchField: "name",
	placeholder: "Выберите эпоху",
	options: [],
	persist: false,
	create: false,

	load: function (query, callback) {
		if (!query.length) {
			return callback();
		}

		$.get("/api/Epoch/find/" + query,
			function (data) {
				if (data.length > 0) {
					$("#Epoch option").remove();

					for (var i = 0; i < data.length; i++) {
						$("#EpochId").append(
							"<option value=\"" + data[i].id + "\">" +
							data[i].name + "</option>");
					}

					callback(data);
				}
			}, "json");
	}
});