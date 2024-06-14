$(document).ready(function () {
    $('#myForm').on('submit', function (e) {
        e.preventDefault();

        $.ajax({
            url: '@Url.Action("Add", "User")',
            type: 'POST',
            data: $(this).serialize(),
            success: function (response) {
                if (response.success) {
                    alert('Form submitted successfully.');
                    $('#myForm')[0].reset();
                } else {
                    alert('There was an error processing your request.');
                }
            },
            error: function (xhr, status, error) {
                alert('There was an error sending the request.');
            }
        });
    });
});