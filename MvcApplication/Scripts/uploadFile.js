$(function () {
        var options = {
        valueNames: ['name', 'size']
    };

    var fileList = new List('files', options);

    Dropzone.autoDiscover = false;

    //File Upload response from the server
    //and limit option to send only max 2 file to the server
    $("#dropzoneForm").dropzone({        
        paramName: "file",
        maxFiles: 2,
        success: function (file, response) {
            var obj = JSON.parse(response);
            for (var i = 0; i < obj.length; i++) {
                if (obj[i].Message.toLowerCase() == 'success') {
                    console.log("uploaded");
                    fileList.add({
                        name: obj[i].Name,
                        size: obj[i].Size
                    });
                }
                else {
                    if (obj[i].Message.toLowerCase() == 'error') {
                        console.log("error");
                        $("#myModal").modal();
                    }
                }
            }       
        },       
        maxfilesexceeded: function (file) {
            this.removeFile(file);
            alert("No more files please!");            
        }
    });
});
