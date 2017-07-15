$(function() {

	$(".demo .box").draggable({
		connectToSortable: ".column", //排序
		helper: "clone",
		revert: true,
		//		handle: ".drag",
		/**
		 * 结束的时候把他添加
		 */
		stop: function(e, t) {
			var element = $(this).clone();
			console.log(element);
			var ale = addbodyiframe(element);
			console.log(ale + 'zzzzzzzzz');
		}
	});
	
	$(".box #clole").draggable({
		helper:"clone",
		revert:true,
		handle:".drag",
		stop:function(e,t){
			var element = $(this).clone();
			console.log(element);
			var ale = addbodyiframe(element);
			console.log(ale + 'zzzzzzzzz');
		}
	});
	/**
	 * 添加进能够排序的标签中
	 * @param {Object} element
	 */
	function addbodyiframe(element){
		$('body').find('.span12').append(element);
		return $('body').html();
	}
	$('.lyrow .remove').click(function(){
		 $('body').find('.span12 .box').remove();
	});
})