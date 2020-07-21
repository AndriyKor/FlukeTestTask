import React, { useState, useEffect } from "react";
import axios from "axios";
import { Container } from "semantic-ui-react";
import { EventGrid } from "../../features/events/EventGrid";
import { IEvent } from "../models/event";
import { paginate } from "../../utils/paginate";
import { options } from "../../options/options";

const App = () => {
  const [events, setEvents] = useState<IEvent[]>([]);
  const [eventsDisplay, setEventsDisplay] = useState<IEvent[]>([]);
  const [selectedEvent, setSelectedEvent] = useState<IEvent | null>(null);
  const [currentPage, setCurrentPage] = useState<number>(1);

  useEffect(() => {
    axios.get("http://localhost:5002/api/events").then((response) => {
      setEvents(response.data);

      const eventList = response.data.slice(0, options.pageSize);
      setEventsDisplay(eventList);
    });
  }, []);

  const handleSelectEvent = (id: string) => {
    axios.get("http://localhost:5002/api/events/" + id).then((response) => {
      setSelectedEvent(response.data);
    });
  };

  const handleSelectPage = (page: number) => {
    setCurrentPage(page);

    const eventList = paginate(events, page, options.pageSize);
    setEventsDisplay(eventList);
  };

  return (
    <Container>
      <EventGrid
        events={eventsDisplay}
        totalEvents={events.length}
        currentPage={currentPage}
        pageSize={options.pageSize}
        selectedEvent={selectedEvent}
        selectEvent={handleSelectEvent}
        selectPage={handleSelectPage}
      />
    </Container>
  );
};

export default App;
