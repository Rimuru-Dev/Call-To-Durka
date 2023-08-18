mergeInto(LibraryManager.library, {
	_focusCallback: undefined,
  _unFocusCallback: undefined,

  OnFcous: function(){
  	_focusCallback();
  },

  OnUnfocus: function(){
  	_unFocusCallback();
  },

  FocusAppHandleInit: function(focusCallback, unFocusCallback){
  	_focusCallback = focusCallback;
  	_unFocusCallback = unFocusCallback;

	  window.addEventListener("focus", function(){
  		dynCall('v', _focusCallback, []);
  	});

	  window.addEventListener("blur", function(){
  		dynCall('v', _unFocusCallback, []);
  	});

    document.addEventListener("visibilitychange", function(){
      if(document.hidden){
        dynCall('v', _unFocusCallback, []);
        console.log("Hide app");
      } else{
        dynCall('v', _focusCallback, []);
        console.log("Visible app");
      }
    });
  },
});