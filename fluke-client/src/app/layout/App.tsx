import React, { useState, useEffect } from "react";
import axios from "axios";
import { Container } from "semantic-ui-react";
import { EventGrid } from "../../features/events/EventGrid";
import { IEvent } from "../models/event";

const App = () => {
  const [events, setEvents] = useState([]);
  const [selectedEvent, setSelectedEvent] = useState<IEvent | null>(null);

  useEffect(() => {
    axios.get("http://localhost:5002/api/events").then((response) => {
      setEvents(response.data);
    });
  }, []);

  const handleSelectEvent = (event: IEvent) => {
    setSelectedEvent(event);
  };

  return (
    <Container style={{ marginTop: "20px" }}>
      <EventGrid
        events={events}
        selectedEvent={selectedEvent}
        selectEvent={handleSelectEvent}
      />
    </Container>
  );
};

export default App;
