Vue.filter('formatDateShort', function (value) {
    if (value)
        return (new Date(Date.parse(value))).toLocaleDateString();
    else
        return "";
});

Vue.filter('formatDateTime', function (value) {
    if (value) {
        const m = new Date(Date.parse(value));
        var dateString =
            ("0" + (m.getUTCMonth() + 1)).slice(-2) + "/" +
            ("0" + m.getUTCDate()).slice(-2) + "/" +
            m.getUTCFullYear() + " " +
            ("0" + m.getUTCHours()).slice(-2) + ":" +
            ("0" + m.getUTCMinutes()).slice(-2);

        return dateString; // MM/DD/YYYY HH:MM
    } else {
        return "";
    }
});