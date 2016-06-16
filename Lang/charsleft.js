 
        function count_show(fieldname, maxlimit, showname) {
            var e1 = document.forms[0].elements[fieldname];
            var s1 = e1.value;
            if (s1.length > maxlimit) e1.style.color = 'red';
            else e1.style.color = 'black';

            document.getElementById(showname).innerHTML = maxlimit - s1.length;
        }
