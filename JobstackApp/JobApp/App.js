
import { StyleSheet,ScrollView, Image, Text, View } from 'react-native';
import vacancies from './assets/vacancies.json'

const App=()=> {


const filtered = vacancies.filter(obj => {
  return obj.id === 2;
});

// const found = vacancies.find(obj => {
//   return obj.id === 2;
// });
// console.log(found.titleName);
// console.log(filtered[0].titleName);

  return (
    <View style={styles.container}>
          {/* {vacancies.map((post)=>(
                <Text >{post.titleName}</Text>
                
           ))} */}


            {/* {filtered.map(obj => {
              return (
                <Text>{obj.address}</Text> 
              )
            })} */}
            
            {/* {found && (
                  <Text>{found.address}</Text>
              )} */}
             <Text>Hello World</Text>
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
