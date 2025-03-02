
const productList = addEventListener("load", async () => {
    DrawProducts()
    CategoryList()
    let categoryIdArr = [];
    let basketarr = JSON.parse(sessionStorage.getItem("basket"))||[];
    sessionStorage.setItem("categoryIds", JSON.stringify(categoryIdArr))
    sessionStorage.setItem("basket", JSON.stringify(basketarr))
    document.querySelector("#ItemsCountText").innerHTML = basketarr.length 

})

const getAllDetailsFromFormForRegister = () => {
    const UserName = document.getElementById("username").value
    const Password = document.querySelector("#password").value
    const FirstName = document.querySelector("#firstname").value
    const LastName = document.querySelector("#lastname").value
    if (!UserName || !Password || !FirstName || !LastName) {

        alert("all filed is requred")
    }
    else {
        return ({
            UserName, Password, FirstName, LastName
        })
    }
}

const GetDitialfromfrom = async () => {
    //document.getElementById("Productlist").innerHTML=''
    document.getElementById("PoductList").innerHTML=''
    let search = {

     nameSearch :document.querySelector("#nameSearch").value,
     minPrice :parseInt(document.querySelector("#minPrice").value),
     maxPrice:parseInt(document.querySelector("#maxPrice").value),
     categoryIds1: JSON.parse(sessionStorage.getItem("categoryIds"))
    }
    return search;

   
    
}
//const addEventListener = addEventListener("load", async () => {

//    DrawProducts()
////})
const filterProducts = async () => {

    DrawProducts()
}

const DrawProducts = async () => {
    //const categoryIds1=[]
    const { nameSearch, minPrice, maxPrice, categoryIds1 } = await GetDitialfromfrom();
    console.log(categoryIds1)
    let url =`api/Product/`
    if (minPrice || maxPrice || nameSearch || categoryIds1) { 
        url += '?'
    if (nameSearch!='')
        url += `&desc=${nameSearch}`
    if (minPrice)
        url += `&minPrice=${minPrice}`
    if (maxPrice)
        url += `&maxPrice=${maxPrice}`
    if (categoryIds1 != []) {
        for (let i = 0; i < categoryIds1.length; i++) {
            url += `&categoryIds=${categoryIds1[i]}`
        }
    }
  }
       

    const AllProducts = await fetch(url, {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json'
        },

        query: {
             desc:nameSearch,
             minPrice: minPrice,
             maxPrice: maxPrice,
             categoryIds:categoryIds1 
        }
       
    });
    if (AllProducts.ok) {
        const dataProducts = await AllProducts.json();
        console.log('GET Data:', dataProducts)
        showAllProducts(dataProducts)
        //CategoryList()
        }
}
const showAllProducts = async (products) => {
    for (let i = 0; i < products.length; i++) {
        showOneProduct(products[i]);
    }
}
const showOneProduct = async (product) => {
    let tmp = document.getElementById("temp-card");
    let cloneProduct = tmp.content.cloneNode(true)
    cloneProduct.querySelector("img").src = "./images/" + product.image
    cloneProduct.querySelector("h1").textContent = product.name
    cloneProduct.querySelector(".price").innerText = product.price
    cloneProduct.querySelector(".description").innerText = product.descreption
    cloneProduct.querySelector("button").addEventListener('click', () => { addToCart(product) })
    document.getElementById("PoductList").appendChild(cloneProduct)
}
const CategoryList = async () => {

    const showAllCatgories = await fetch("api/Category", {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json'
        }
    });

    allCategories = await showAllCatgories.json();
    for (let i = 0; i < allCategories.length; i++) {
        showOneCategory(allCategories[i]);
    }

}

const showOneCategory = async (category) => {
    console.log(category)
    let tmp = document.getElementById("temp-category");
    let cloneCategory = tmp.content.cloneNode(true)
 
    cloneCategory.querySelector(".OptionName").textContent = category.categoryName
   
    cloneCategory.querySelector(".opt").addEventListener('change', () => { FilterCategory(category) })
    document.getElementById("categoryList").appendChild(cloneCategory)
}
const addToCart = (product) => {
  /*  if (sessionStorage.getItem("userId")) {*/

        let myCart = JSON.parse(sessionStorage.getItem("basket"))
        myCart.push(product.productid)
        sessionStorage.setItem("basket",JSON.stringify(myCart))

        document.querySelector("#ItemsCountText").innerHTML = myCart.length 
    }
 
        //alert("אינך רשום")
        //window.location.href = "user.html"
    


const FilterCategory = (category) => {

    let categories = JSON.parse(sessionStorage.getItem("categoryIds"))
    let c = categories.indexOf(category.categoryId)
    c == -1 ? categories.push(category.categoryId) : categories.splice(c, 1)
    sessionStorage.setItem("categoryIds", JSON.stringify(categories))
    console.log(categories)
    DrawProducts()

}



   
    const update = async () => {
        newUser = getAllDetailsFromFormForRegister()

        const responsePut = await fetch(`api/user/${sessionStorage.getItem('userId')}`, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(newUser)
        });
        if (responsePut.ok) {

            alert("update sucsses")
        }
        else
            alert("update not sucsses")
    }


/*DrawProducts()*/





