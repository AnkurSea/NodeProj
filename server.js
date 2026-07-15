const express = require("express");
const app=express();

app.get("/ankur",(req,res)=>{
    debugger
    res.send("Hi");
})

app.listen(4000,()=>console.log("test"));