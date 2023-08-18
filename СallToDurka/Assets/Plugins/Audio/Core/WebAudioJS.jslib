mergeInto(LibraryManager.library, 
    {
        PlayAudioExtern: function (sourceID, clipPath, loop, volume, mute) {
            sourceID = UTF8ToString(sourceID);
            clipPath = UTF8ToString(clipPath);
            
            window.PlayAudio(sourceID, clipPath, loop, volume, mute);
        },

        SetSourceLoopExtern: function (sourceID, loop){
            sourceID = UTF8ToString(sourceID);

            window.SetAudioSourceLoop(sourceID, loop);
        },

        SetAudioSourceVolume: function (sourceID, value){
            sourceID = UTF8ToString(sourceID);

            window.SetAudioSourceVolume(sourceID, value);
        },

        SetAudioSourceMute: function  (sourceID, value){
            sourceID = UTF8ToString(sourceID);

            window.SetAudioSourceMute(sourceID, value);
        },

        StopAudioSource: function  (sourceID){
            sourceID = UTF8ToString(sourceID);

            window.StopAudioSource(sourceID);
        },

        MuteExtern: function (value){
            window.AudioMute(value);  
        },

        SetGlobalVolume: function (value){
            window.SetGlobalVolume(value);  
        },

        DeleteAudioSource: function(sourceID){
            sourceID = UTF8ToString(sourceID);

            window.DeleteAudioSource(sourceID);
        },

        SetAudioSourcePitch: function(sourceID, value){
            sourceID = UTF8ToString(sourceID);

            window.SetAudioSourcePitch(sourceID, value);
        },
    }
);

