$(document).ready(function(){
    
    $("#test").html("<a href=''>aaa</a>");
    
    setTimeout(function(){
        $('#loading').remove();
        $('#loading-mask').fadeOut({remove:true});
    }, 250);
});