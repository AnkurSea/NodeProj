const express = require("express");
const app=express();

app.get("/ankur",(req,res)=>{
    debugger
    res.send("Hibfbf");
})

app.listen(4000,()=>console.log("test55"));