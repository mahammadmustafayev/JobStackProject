import { StyleSheet,ScrollView, Text,Button, View ,StatusBar} from 'react-native';

import { EvilIcons } from '@expo/vector-icons';
import { Feather } from '@expo/vector-icons';
import vacancies from '../assets/vacancies.json'

const Home = ({navigation}) => {
  return (
    <ScrollView >
      <View style={styles.container}>
        <StatusBar backgroundColor={'#059669'} style="light"/>
        <Text style={styles.textCenter}>Job Stack</Text>
      </View>
      <View style={styles.mainScroll}>
      {vacancies.map((vacancy)=>(
         <View style={styles.vacancyView}>
             <View style={styles.differentParent}>
                 <View style={styles.firstChild}>
                   <Text style={styles.vacancyName}>{vacancy.titleName}</Text>
                   <Text style={styles.companyName}>by {vacancy.company.companyName}</Text>
                 </View>
                 <View style={styles.secondChild}>
                     <Text style={styles.details} onPress={()=>navigation.navigate('Details',{
                       itemId:vacancy.id
                     })}><Feather name="arrow-up-right"  size={24} color="#059669" /></Text>
                     {/* <Button style={styles.details}  onPress={()=>navigation.navigate('Details')}>
                        <Feather name="arrow-up-right"  size={24} color="#059669" />
                     </Button> */}
                 </View>
             </View>
             <View style={styles.others}>
                  <Text style={styles.jobType}>{vacancy.jobType.typeName}</Text>
                  <Text style={styles.country}><EvilIcons name="location" size={20} color="#33ac9e" /> {vacancy.country.name}</Text>
                  <Text style={styles.salary}>{vacancy.salary}</Text>
             </View>
         </View>
        ))}
      </View>
         
    </ScrollView>
  )
}

export default Home;

const styles = StyleSheet.create({
    container: {
        display:'flex',
        justifyContent:'center',
        alignItems:'center',
        // paddingTop:5,
        width:400,
        height:90,
        backgroundColor:'#059669',
      },
      textCenter:{
         color:'white',
         fontSize:23,
         fontWeight:'bold',
      },
      mainScroll:{
          marginLeft:3,
          marginTop:5,
          width:385,
          height:'auto',
          // height:1000,
         // backgroundColor:'red'
      },
      vacancyView:{
         width:385,
         height:170,
         backgroundColor:'#fff',
         borderWidth:1,
         borderStyle:'solid',
         borderColor:'#e3fff4',
         borderRadius:10,
         marginTop:5
      },
      differentParent:{
        width:340,
        height:67,
        marginLeft:20,
        //backgroundColor:'red',
        display:'flex',
        flexDirection:'row'
      },
      firstChild:{
        width:170,
        height:67,
        //backgroundColor:'cyan'
      },
      secondChild:{
        width:170,
        height:67,
       // backgroundColor:'blue'
      },
      details:{
         width:50,
         textAlign:'center',
         height:50,
         backgroundColor:'#f2faf7',
         borderRadius:50,
         marginLeft:120,
         marginTop:10,
         paddingTop:12,
      },
      vacancyName:{
        color:'black',
        paddingLeft:10,
        paddingTop:15,
        fontSize:22,
        fontWeight:'500',
        width:400
      },
      companyName:{
         paddingLeft:10,
         color:'#a0aec8'
      },
      vacancyDay:{
        textAlign:'right',
        paddingRight:15,
        
      },
      others:{
         display:'flex',
         flexWrap:'wrap',
         flexDirection:'column',
         gap:1,
         width:200,
         height:90,
         marginTop:15,
        // backgroundColor:'cyan',
         marginLeft:20
      },
      jobType:{
        textAlign:'center',
        paddingTop:3,
        borderRadius:20,
        borderColor:'#fff8f3',
        borderStyle:'solid',
        borderWidth:1,
        width:'auto',
        height:30,
        fontSize:15,
        fontWeight:'400',
        marginTop:5,
        backgroundColor:'#fff8f3',
        color:'#f97b2b'
      },
      salary:{
        textAlign:'center',
        paddingTop:3,
        borderRadius:20,
        borderColor:'#f9f5fe',
        borderStyle:'solid',
        borderWidth:1,
        width:100,
        height:30,
        fontSize:15,
        fontWeight:'400',
        marginTop:5,
        backgroundColor:'#f9f5fe',
        color:'#d99dec',
      },
      country:{
        textAlign:'center',
        paddingTop:3,
        borderRadius:20,
        borderColor:'#f2faf7',
        borderStyle:'solid',
        borderWidth:1,
        width:'auto',
        height:30,
        fontSize:15,
        fontWeight:'400',
        marginTop:5,
        backgroundColor:'#f2faf7',
        color:'#33ac9e'
      },
})