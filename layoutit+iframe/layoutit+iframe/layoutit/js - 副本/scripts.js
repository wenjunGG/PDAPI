/**
 * 删除布局的方法
 */
function removeElm() {
	$(".demo").delegate(".remove", "click", function(e) {
		e.preventDefault();
		$(this).parent().remove();
		//		if($(this).parent().parent=$(".row-fluid"))
		//		$(".row-fluid").remove();
		if(!$(".demo .lyrow").length > 0) {
			//			clearDemo()
			console.log("超出限制了的remove!");
		}
	})
}
var stopsave = 0; //******保存
var startdrag = 0; //*****拖动

$(document).ready(function() {
	//	var ifm=$("#iframe");
	//	var iframe=$(ifm[0].contentWindow.document.body);

	$("body").css("min-height", $(window).height() - 90);
	$(".demo").css("min-height", $(window).height() - 160);

})
window.onload = function() { //窗口加载完毕执行
	//iframe对象
	var _iframe = document.getElementById('iframe').contentWindow;
	//父布局
	var demo = _iframe.document.getElementsByClassName("demo");
	//可排序布局
	var column = _iframe.document.getElementsByClassName("column");

	var drags = _iframe.document.getElementsByClassName("drag");
	/**
	 * 动态添加布局排版函数*******************************
	 */
	function initContainer() {
		$(column).sortable({
			connectWith: column,
			opacity: .35,
			//		handle: ".drag",
			start: function(e, t) {
				if(!startdrag) stopsave++;
				startdrag = 1;
			},
			stop: function(e, t) {
				if(stopsave > 0) stopsave--;
				startdrag = 0;
			}
		});
	}
	//	$(column).draggable();
	//	window.frames["iframe"].document.getElementById("liesa").draggable();
	//	var akk=$("#iframe").contents().find("#liesa").draggable();
	//	akk.draggable(); 
	/***
	 * 此段代码为布局设计拖动代码
	 */
	$(".sidebar-nav .lyrow").draggable({
		connectToSortable: column,
		iframeFix: true,
		helper: "clone",
		handle: ".drag",
		drag: function(e, t) {
			t.helper.width(400)
		},
		//拖动停止的时候
		stop: function(e, t) {
			$(column).sortable({
				opacity: .35,
				connectWith: column,
				stop: function(e, t) {
					if(stopsave > 0) stopsave--;
					startdrag = 0;
				}
			});
			if(stopsave > 0) stopsave--;
			startdrag = 0;

		}
	});
	/**
	 * 此代码为保存代码**********************
	 */
	initContainer();
	removeElm(); //刪除組件
}