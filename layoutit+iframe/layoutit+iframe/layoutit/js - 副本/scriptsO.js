/**
 * 删除布局的方法
 */
function removeElm() {
	$(".demo").delegate(".remove", "click", function(e) {
		e.preventDefault();
		$(this).parent().remove();
		if(!$(".demo .lyrow").length > 0) {
			//			clearDemo()
			console.log("超出限制了的remove!");
		}
	})
}
var stopsave = 0; //******保存
var startdrag = 0; //*****拖动
/**
 * 动态添加布局排版函数*******************************
 */
function initContainer() {
	$(".demo, .demo .column").sortable({
		connectWith: ".column",
		opacity: .35,
		handle: ".drag",
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

$(document).ready(function() {
	$("body").css("min-height", $(window).height() - 90);
	$(".demo").css("min-height", $(window).height() - 160);

	/***
	 * 此段代码为布局设计拖动代码
	 */
	$(".demo .lyrow").draggable({
		connectToSortable: ".demo",
		helper: "clone",
		handle: ".drag",
		drag: function(e, t) {
			t.helper.width(400)
		},
		//拖动停止的时候
		stop: function(e, t) {
			$(".demo .column").sortable({
				opacity: .35,
				connectWith: ".column",

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
})