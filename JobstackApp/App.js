import { useState,useEffect } from 'react';
import {  Text, View,StatusBar,StyleSheet } from 'react-native';

const App = () => {
   const [data, setData] = useState([])
   const [loading, setLoading] = useState(true)
   // const url= 'http://localhost:7264/api/JobTypes/GetAllTypes'
   const url= 'https://jsonplaceholder.typicode.com/posts'
   useEffect(() => {
     fetch(url)
       .then((response)=>response.json())
       .then((json)=>setData(json)) 
       .catch((err)=>console.error(err))
       .finally(()=>setLoading(false))
   }, [])
   
  return (
    <View style={styles.container}>
       {loading ? <Text>Loading ....</Text>:(
           data.map((post)=>(
               <View>
                  <Text>{post.id}</Text>
               </View>
            ))
        )}
    </View>
  );
};

export default App;

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: '#fff',
    alignItems: 'center',
    justifyContent: 'center',
  },
});
