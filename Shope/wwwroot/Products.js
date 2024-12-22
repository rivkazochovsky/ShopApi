const GetDitialfromfrom =async () => {
    const search = {
     nameSearch : document.querySelector("#nameSearch").value,
     minPrice :parseInt(document.querySelector("#minPrice").value),
     maxPrice:parseInt(document.querySelector("#maxPrice").value)

    }
    return search;

   
    
}
//const addEventListener = addEventListener("load", async () => {

//    DrawProducts()
//})
const filterProducts = async () => {

    DrawProducts()
}

const DrawProducts = async () => {
    const categoryIds1=[]
    const { nameSearch, minPrice, maxPrice } = await GetDitialfromfrom();
    let url =`api/Product/`
    if (minPrice || maxPrice || nameSearch ||categoryIds1)
        url += '?'
    if (nameSearch!='')
        url += `&desc=${nameSearch}`
    if (minPrice)
        url += `&minPrice=${minPrice}`
    if (maxPrice)
        url += `&maxPrice=${maxPrice}`
    if (categoryIds1!='')
        url += `&categoryIds=${categoryIds1}`

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
    //cloneProduct.querySelector(".button").addEventListener('click', () => { addToCart(product) })
    document.getElementById("PoductList").appendChild(cloneProduct)
}
DrawProducts()
//////    else
//////        alert("bed req")
//////}
///*DrawProducts()*/
//DrawProducts()

////const TrackLinkID = async () => {
////}


//const filterProducts = async () => {

//    alert("njb")
//}

