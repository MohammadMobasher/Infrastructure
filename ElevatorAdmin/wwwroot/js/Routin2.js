function removeDefaultRoutineButtonCancel(id) {
    $('#routine_record_action_Cancel_' + id).css({
        position: 'absolute',
        zIndex: -1,
        width: 0,
        height: 0,
        overflow: 'hidden',
        pointerEvents: 'none'
    });
}

function routineSubmitCancel(id, description) {
    console.group('routineSubmitCancel');
    console.log('do the cancel action for id : ' + id);
    var $container = $('#Routine_Action_Cancel_' + id);

    if ($container.length === 0) {
        console.log('there is no routine cancel button for id : ' + id);
        console.log('maybe we are in popup, searching parent');
        $container = window.parent.$('#Routine_Action_Cancel_' + id);

        if ($container.length === 0) {
            console.log('nothing found, maybe you missed something, check the routine step and its type');
        }
    }

    $container.find('form [name="Description"]').val(description);
    $container.find('form').submit();
    closeFancybox();
    console.groupEnd();
}

function removeDefaultRoutineButtonEdit(id) {
    $('#routine_record_action_Edit_' + id).css({
        position: 'absolute',
        zIndex: -1,
        width: 0,
        height: 0,
        overflow: 'hidden',
        pointerEvents: 'none'
    });
}

function routineSubmitEdit(id, description) {
    console.group('routineSubmitEdit');
    console.log('do the edit action for id : ' + id);
    var $container = $('#Routine_Action_Edit_' + id);

    if ($container.length === 0) {
        console.log('there is no routine edit button for id : ' + id);
        console.log('maybe we are in popup, searching parent');
        $container = window.parent.$('#Routine_Action_Edit_' + id);

        if ($container.length === 0) {
            console.log('nothing found, maybe you missed something, check the routine step and its type');
        }
    }

    $container.find('form [name="Description"]').val(description);
    $container.find('form').submit();
    closeFancybox();
    console.groupEnd();
}

function removeDefaultRoutineButtonNext(id) {
    $('#routine_record_action_Next_' + id).css({
        position: 'absolute',
        zIndex: -1,
        width: 0,
        height: 0,
        overflow: 'hidden',
        pointerEvents: 'none'
    });
}

function routineSubmitNext(id, description) {
    console.group('routineSubmitNext');
    console.log('do the cancel next for id : ' + id);
    var $container = $('#Routine_Action_Next_' + id);

    if ($container.length === 0) {
        console.log('there is no routine next button for id : ' + id);
        console.log('maybe we are in popup, searching parent');
        $container = window.parent.$('#Routine_Action_Next_' + id);

        if ($container.length === 0) {
            console.log('nothing found, maybe you missed something, check the routine step and its type');
        }
    }

    $container.find('form [name="Description"]').val(description);
    $container.find('form').submit();
    closeFancybox();
    console.groupEnd();
}

function removeDefaultRoutineButtonOk(id) {
    $('#routine_record_action_Ok_' + id).css({
        position: 'absolute',
        zIndex: -1,
        width: 0,
        height: 0,
        overflow: 'hidden',
        pointerEvents: 'none'
    });
}

function routineSubmitOk(id, description) {
    console.group('routineSubmitOk');
    console.log('do the ok action for id : ' + id);
    var $container = $('#Routine_Action_Ok_' + id);

    if ($container.length === 0) {
        console.log('there is no routine ok button for id : ' + id);
        console.log('maybe we are in popup, searching parent');
        $container = window.parent.$('#Routine_Action_Ok_' + id);

        if ($container.length === 0) {
            console.log('nothing found, maybe you missed something, check the routine step and its type');
        }
    }

    $container.find('form [name="Description"]').val(description);
    $container.find('form').submit();
    closeFancybox();
    console.groupEnd();
}

function getRecordApp(id) {
    return window['app_record'][id];
}

function closeFancybox() {
    console.group('closing fancybox');
    try {
        console.log('trying to close fancybox in main window and parent');
        $.fancybox.close(true);
        window.parent.$.fancybox.close(true);
    } catch (e) {
        console.log('something went wrong');
        console.error(e);
    }
    console.groupEnd();
}

function closeFancyboxOneLevel() {
    console.group('closing fancybox');
    try {
        console.log('trying to close fancybox in main window --one level');
        $.fancybox.close(true);
    } catch (e) {
        console.log('something went wrong');
        console.error(e);
    }
    console.groupEnd();
}

function closeFancyboxAndShowServiceResult(serviceResult) {
    closeFancybox();
    console.log(serviceResult);
    showBeautyMessage(serviceResult);
}

function showBeautyMessage(res) {
    debugger;
    //var aaa = {succeed: res.Succeed,message: res.Message};
    res = keyLowerCase(res) || {};
    debugger
    swal({
        title: (res.succeed ? 'موفق' : 'خطا'),
        text: res.message || (res.succeed ? 'عملیات با موفقیت انجام شد' : "عملیات با خطا مواجه شد"),
        type: res.succeed ? 'success' : 'error',
        confirmButtonText: "تایید",
        html: true
    });

}

function keyLowerCase(data) {
    var key, keys = Object.keys(data);
    var n = keys.length;
    var newobj = {};

    while (n--) {
        key = keys[n];
        newobj[key.toLowerCase()] = data[key]
    }
    return newobj;
}



var Routine2 = {};

Routine2.RemoveButton = function (entityId, action) {
    console.log(entityId, action);
    $('#routine_record_action_tooltip_' + action + '_' + entityId).css({
        position: 'absolute',
        zIndex: -1,
        width: 0,
        height: 0,
        overflow: 'hidden',
        pointerEvents: 'none'
    });
};

Routine2.DoAction = function (id, action, description) {
    debugger;
    console.group('routineSubmitOk');
    console.log('do the ok action for id : ' + id);
    var $container = $('#Routine_Action_' + action + '_' + id);

    console.log($container);

    if ($container.length === 0) {
        console.log('there is no routine ok button for id : ' + id);
        console.log('maybe we are in popup, searching parent');
        $container = window.parent.$('#Routine_Action_' + action + '_' + id);

        if ($container.length === 0) {
            console.log('nothing found, maybe you missed something, check the routine step and its type');
        }
    }

    $container.find('form [name="Description"]').val(description);
    $container.find('form').submit();
    closeFancybox();
    console.groupEnd();
}



$(function () {

    $(document).on('keyup', '.txtSearchErea', function (event) {
        var keycode = (event.keyCode ? event.keyCode : (event.which ? event.which : event.charCode));
        // درصورتی که اینتر شده باشد
        if (keycode == 13) {
            $('.btn-search').trigger("click");
        }
    });


    $(document).on('change', '.ddlSearchErea', function () {
        $('.btn-search').trigger("click");
    });

});