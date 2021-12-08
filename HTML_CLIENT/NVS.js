const URI = "http://snizhel.somee.com/api/employees";


function page_Load(){
    laydanhsach();
}

function btnSearch_Click(){
    var keyword = document.getElementById("txtKeyword").value.trim();
    if(keyword.length > 0){
        search(keyword);
    }else{
        laydanhsach();
    }
}

function lnkID_Click(Manv){
    getDetails(Manv);
}

function btnAdd_Click(){
    var newnhanvien = {
        ID:0,
        Name: document.getElementById("txtName").value,
        Address: document.getElementById("txtAddress").value,
        Salary: document.getElementById("txtSalary").value,
        Age: document.getElementById("txtAge").value
    };
    addNew(newnhanvien);
}

function btnUpdate_Click(){
    var newnhanvien = {
        ID:document.getElementById("txtID").value,
        Name: document.getElementById("txtName").value,
        Address: document.getElementById("txtAddress").value,
        Salary: document.getElementById("txtSalary").value,
        Age: document.getElementById("txtAge").value
    };
    update(newnhanvien);
}

function btnDelete_Click(){
    if(confirm("ARE YOU SURE?")){
        var manv = document.getElementById("txtID").value;
        deletee(manv);
    }
}

function laydanhsach() { 
    axios.get(URI).then((response)=>{
      var employee = response.data;
      renderNVList(employee);
    });
}   

function search(keyword){
  axios.get(URI+"/search/"+keyword).then((response)=>{
    var employee = response.data;
    renderNVList(employee);
  });
}

function getDetails(ID){
  axios.get(URI+"/"+ID).then((response)=>{
    var employee = response.data;
    renderNVDetails(employee);
  });
}

function addNew(newnhanvien){
  axios.post(URI,newnhanvien).then((response)=>{
    var employee = response.data;
    if(employee){
      laydanhsach();
    }
    else{
      alert("no value");
    }
  });
}

function update(newnhanvien){
  axios.put(URI+"/"+newnhanvien.ID,newnhanvien).then((response)=>{
    var employee = response.data;
    if(employee){
      laydanhsach();
      clearTextboxes();
    }
    else{
      alert("no value");
    }
  });
}

function deletee(ID){
  axios.delete(URI+"/"+ID).then((response)=>{
    var employee = response.data;
    if(employee){
      laydanhsach();
    }
    else{
      alert("no value");
    }
  });
}

function renderNVList(nhanviens){
    var rows = "";
    for(var Employee of nhanviens){
        rows += "<tr onclick='lnkID_Click(" + Employee.ID + ")' style='cursor:pointer'>";
        rows += "<td>" + Employee.ID + "</td>";
        rows += "<td>" + Employee.Name + "</td>";
        rows += "<td>" + Employee.Address + "</td>";
        rows += "<td>" + Employee.Salary + "</td>";
        rows += "<td>" + Employee.Age + "</td>";
        rows += "</td>";
    }
    var header = "<tr><th>ID</th><th>Name</th><th>Address</th><th>Salary</th><th>Age</th></tr>";
    document.getElementById("lstNVS").innerHTML = header + rows;
}

function renderNVDetails(nhanvien){
    document.getElementById("txtID").value = nhanvien.ID;
    document.getElementById("txtName").value = nhanvien.Name ;
    document.getElementById("txtAddress").value = nhanvien.Address;
    document.getElementById("txtSalary").value = nhanvien.Salary;
    document.getElementById("txtAge").value = nhanvien.Age;
}

function clearTextboxes(){
    document.getElementById("txtID").value ='';
    document.getElementById("txtName").value ='';
    document.getElementById("txtAddress").value ='';
    document.getElementById("txtSalary").value ='';
    document.getElementById("txtAge").value ='';
}

