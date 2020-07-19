import React, { useState, useEffect } from "react";
import axios from "axios";
import { EventTable } from "../../features/events/EventTable";
import { Container } from "semantic-ui-react";

const App = () => {
  const [events, setEvents] = useState([]);

  useEffect(() => {
    axios.get("http://localhost:5002/api/events").then((response) => {
      console.log(response.data);
      setEvents(response.data);
    });
  }, []);

  return (
    <Container style={{ marginTop: "20px" }}>
      <EventTable events={events} />
    </Container>
  );
};

export default App;
