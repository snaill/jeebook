$(document).ready(function(){
    
    $("#navbar").pathnavbar({
        path : '/aa/bb'
        });
    
    setTimeout(function(){
        $('#loading').remove();
        $('#loading-mask').fadeOut({remove:true});
    }, 250);
});