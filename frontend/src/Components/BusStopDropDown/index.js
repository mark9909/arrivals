import { useState, useEffect } from 'react'
import css from '../../styles.css'
import axios from 'axios'

const BusStopGrid = () => {
    const [stops, setStops] = useState([])
    const [timer, setTimer] = useState(undefined)

    // Qdo a pagina carregar
    useEffect(() => 
    {
      executeRouteRequest();
      const interval = setInterval(() => {
        executeRouteRequest();
      }, 60000);
      return () => clearInterval(interval);


      
    }, [])

    // Proximo reauest pra listar as rotas
    const executeRouteRequest = async () => {
      const response = await axios.get('https://localhost:7259/BusSchedulle')
      setStops(response.data)
    }

    return (

      
            <div id="mainContent" className="container" style={{display: 'grid', gridTemplateColumns: 'repeat(1, 1fr)', gridGap: '10px', gridAutoRows: 'minMax(100px, auto)'}}>
              {stops.map((item) => (
                <div>
                  {item.busStop} - {item.busMessage}
                </div>
              ))}
            </div>
    )
}

export default BusStopGrid