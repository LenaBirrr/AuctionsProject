
$("#AuctionItemId").selectize({
	plugins: ["remove_button"],
	valueField: "id",
	labelField: "id",
	searchField: "id",
	placeholder: "Выберите вещь",
	options: [],
	persist: false,
	create: false,

	load: function (query, callback) {
		if (!query.length) {
			return callback();
		}

		$.get("/api/AuctionItem/find/" + query,
			function (data) {
				if (data.length > 0) {
					$("#AuctionItem option").remove();

					for (var i = 0; i < data.length; i++) {
						$("#AuctionItemId").append(
							"<option value=\"" + data[i].id + "\">" +"</option>");
					}

					callback(data);
				}
			}, "json");
	}
});