import { useEffect, useState } from "react";
import "./App.css";
import axios from "axios";
import { Header, List } from "semantic-ui-react";

function App() {
  const [activities, setActivities] = useState([]);

  useEffect(() => {
    axios.get("http://localhost:5000/api/activities").then((response) => {
      setActivities(response.data);
    });
  }, []);

  console.log(activities);
  return (
    <div>
      <Header as="h1" icon="users" content="Reactivities" />
      <List bulleted={true}>
        {activities.map((activity: any) => (
          <List.Item key={activity.id} content={activity.title} />
        ))}
      </List>
    </div>
  );
}

export default App;
