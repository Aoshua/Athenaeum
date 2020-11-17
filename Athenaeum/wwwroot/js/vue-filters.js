Vue.filter('formatDateShort', function (value) {
    return (new Date(Date.parse(value))).toLocaleDateString();
});