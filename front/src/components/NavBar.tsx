import {
  Breadcrumb, BreadcrumbItem, BreadcrumbLink,} from '@chakra-ui/react'
import { Link } from 'react-router-dom'




export default function NavBar() {
  return (
    <Breadcrumb separator= ' ' color='#8C52FF' fontWeight='600' fontSize='16px'>
      <BreadcrumbItem style={{padding: '10px 32px'}}>
        <BreadcrumbLink as={Link} to= '/'>Home</BreadcrumbLink>
      </BreadcrumbItem>

      <BreadcrumbItem style={{padding: '30px'}}>
        <BreadcrumbLink as={Link} to= '/faq'> FAQ</BreadcrumbLink>
      </BreadcrumbItem>

      <BreadcrumbItem style={{padding: '30px'}}>
        <BreadcrumbLink as={Link} to= '/about'>Desenvolvedores</BreadcrumbLink>
      </BreadcrumbItem>

      <BreadcrumbItem style={{padding: '30px'}}>
        <BreadcrumbLink as={Link} to= '/admin'>Admin</BreadcrumbLink>
      </BreadcrumbItem>
</Breadcrumb>
  )
}
