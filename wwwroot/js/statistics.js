$(document).ready(function(){
    $('#table').DataTable({
        "ajax": '/Team/UpdateStatistics?name=' + name;
    });
});