import { StatusBar } from 'expo-status-bar';
import { useState,useEffect } from 'react';
import { StyleSheet, Text, View } from 'react-native';
import vacancies from './assets/test.json'

const App=()=> {
//  // const url = "https://localhost:7264/api/Countries/GetAllCountries";
//   const url = "https://localhost:7264/api/Countries/Details/1";
//   const [data, setData] = useState([])
//   const [loading, setLoading] = useState(true)
//   const fetchInfo = () => {
//     return fetch(url)
//       .then((res) => res.json())
//       .then((d) => setData(d))
//       .catch((err)=>console.error(err))
//       .finally(()=>setLoading(false))
//   }
//   useEffect(() => {
//     fetchInfo();
//   }, [])
  return (
    <View style={styles.container}>
          {vacancies.map((post)=>(
               <Text>{post.titleName}</Text>
          ))}
     
    </View>
  );
}
export default  App;

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: '#fff',
    alignItems: 'center',
    justifyContent: 'center',
  },
});
