function myMap() {
  var mapCanvas = document.getElementById("map");
  var mapOptions = {
    center: new google.maps.LatLng(51.5, -0.2), zoom: 10
  };
  var map = new google.maps.Map(mapCanvas, mapOptions);
}

$(window).scroll(function(event){
	if($(document).scrollTop() > 300){
		$(".circle").css({
			display : "block",
			bottom: "40px"

			
		});
	}else{
		$(".circle").css({
			display: "none"
		
		});

	}
})

$(".circle").click(function(event){
	 console.log($(document).scrollTop())
	var currentPos = $(document).scrollTop();
	setInterval(function(){
		if(currentPos > 0){
			currentPos -= 15;
			$(document).scrollTop(currentPos);
		}
	},1)
	
	
	
})