import { StyleSheet, Text, View,ScrollView ,StatusBar} from 'react-native'
import { AntDesign } from '@expo/vector-icons';
import { EvilIcons } from '@expo/vector-icons';
import { FontAwesome } from '@expo/vector-icons';
import { MaterialIcons } from '@expo/vector-icons';
import { Entypo } from '@expo/vector-icons';
import { MaterialCommunityIcons } from '@expo/vector-icons';
import { Feather } from '@expo/vector-icons';
import vacancies from '../assets/vacancies.json'
import React from 'react'

const Details = ({route,navigation}) => {
  const { itemId } = route.params;
  const found = vacancies.find(obj => {
     return obj.id === itemId;
  });
  //console.log(found.skillName);
  return (
    <ScrollView>
      <View style={styles.container}>
        <StatusBar backgroundColor={'#059669'} style="light"/>
        <Text style={styles.leftControl} onPress={()=>navigation.navigate('Home')}><AntDesign name="left" size={24} color="white" /></Text>
        <Text style={styles.textCenter} >Details</Text>
      </View>
      <View style={styles.mainDetail}>
        <View style={styles.titleInfos}>
          <Text style={styles.vacancyName}>{found.titleName}</Text>  
          <View style={styles.otherInfos}>
              <Text style={styles.companystyle}><FontAwesome name="building-o" size={26} color="#129b71" /> {found.company.companyName}.</Text>
              <Text style={styles.addressstyle}><EvilIcons name="location" size={26} color="#129b71" />{found.city.cityName},{found.country.name}</Text>
          </View>
        </View>
        <View style={styles.jobInfos}>
            <Text style={styles.infoTypes}><MaterialIcons name="person-search" paddingTop={6} size={18} color="#24a37b" /> {found.jobType.typeName}</Text>
            <Text style={styles.infoTypes}><Entypo name="list" paddingTop={6} size={18} color="#24a37b" /> {found.category.categoryName}</Text>
            <Text style={styles.infoTypes}><MaterialCommunityIcons name="bag-checked" paddingTop={6} size={18} color="#24a37b"  /> {found.experience}</Text>
            <Text style={styles.infoTypes}><Feather name="dollar-sign"  paddingTop={6} size={18} color="#24a37b" /> {found.salary}</Text>
        </View>
        <View style={styles.descInfo}>
            <Text style={styles.descname}>Job Description:</Text>
            <Text style={styles.desc}>{found.description}</Text>
        </View>
        <View style={styles.descInfo}>
            <Text style={styles.descname}>Responsibilities and Duties:</Text>
            {JSON.parse(found.responsibilityName).map((obj)=>(
              <Text style={styles.desc}><AntDesign name="arrowright" size={16} color="#24a37b" />{obj}</Text>
            ))}
            {/* <Text style={styles.desc}><AntDesign name="arrowright" size={16} color="#24a37b" />Lorem ipsum dolor sit amet consectetur adipisicing elit. Est sed quos modi saepe debitis ipsam perspiciatis praesentium sapiente odit aliquid quas unde corrupti dolores illum magni voluptas, deleniti incidunt. Dolor.</Text> */}
        </View>
        <View style={styles.descInfo}>
            <Text style={styles.descname}>Required Experience, Skills and Qualifications:</Text>
            {JSON.parse(found.skillName).map((obj)=>(
              <Text style={styles.desc}><AntDesign name="arrowright" size={16} color="#24a37b" />{obj}</Text>
            ))}
            {/* <Text style={styles.desc}><AntDesign name="arrowright" size={16} color="#24a37b" />Lorem ipsum dolor sit amet consectetur adipisicing elit. Est sed quos modi saepe debitis ipsam perspiciatis praesentium sapiente odit aliquid quas unde corrupti dolores illum magni voluptas, deleniti incidunt. Dolor.</Text> */}
            
        </View>

      </View>
    </ScrollView>
  )
}

export default Details;

const styles = StyleSheet.create({
  container: {
    display:'flex',
   // flexDirection:'row',
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
  leftControl:{
    paddingRight:340,
    position:'absolute',
    top:35
  },
  mainDetail:{
    display:'flex',
    flexDirection:'column',
    gap:10,
    marginLeft:3,
    marginTop:5,
    width:385,
    height:'auto',
   // height:1000,
    backgroundColor:'#F9F9F9'
  },
  titleInfos:{
     width:370,
     height:160,
     backgroundColor:'#fff',
     marginLeft:8,
     borderRadius:7,
     display:'flex',
     flexDirection:'column'
  },
  jobInfos:{
    width:370,
     height:90,
     //backgroundColor:'cyan',
     marginLeft:8,
     display:'flex',
     flexDirection:'row',
     flexWrap:'wrap',
     justifyContent:'center',
     gap:3
  },
  infoTypes:{
     fontSize:15,
     textAlign:'center',
     paddingTop:9,
     width:180,
     height:40,
     backgroundColor:'#fff',
     color:'#24a37b',
     borderRadius:10
  },
  vacancyName:{
     width:'auto',
     height:70,
     fontSize:23,
     fontWeight:'bold',
     //backgroundColor:'#fff',
     paddingTop:18,
     paddingLeft:12
  },
  otherInfos:{
    width:'auto',
    height:90,
   // backgroundColor:'#fff',
    display:'flex',
    flexDirection:'row',
    gap:10,
    paddingTop:12
  },
  descInfo:{
     width:370,
     height:'auto',
    // backgroundColor:'yellow',
     marginLeft:8,
     display:'flex',
     flexDirection:'column',
     gap:12
  },
  descname:{
    fontSize:18,
    fontWeight:'bold',
  },
  desc:{
    color:'#b5aeb1',
    fontSize:15
  },
  companystyle:{
     color:'#b5aeb1',
     paddingLeft:12,
     fontSize:15
  },
  addressstyle:{
    color:'#b5aeb1',
    fontSize:15
  }
})