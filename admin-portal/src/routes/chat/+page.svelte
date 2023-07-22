<script context="module" lang="ts">
	export const prerender = true;
</script>

<script lang="ts">
import {HubConnectionBuilder, HttpTransportType} from '@microsoft/signalr';
import { onMount } from 'svelte';


let connection = new HubConnectionBuilder()
    .withUrl("http://localhost:5207/chat", {withCredentials: false, skipNegotiation: true, transport: HttpTransportType.WebSockets})
    .build();

// Prebaci u state-managment
let serverData = null;
let msg = null;



onMount(() => {
connection.start().catch((e) => console.log("On Mount Err", e));
})

	
connection.on("send", data => {
    console.log("Zasto zoves send?", data);
});
connection.on('receive', data => {
    console.log("Podaci sa servera", data)
    serverData = serverData ? serverData + data : data;
})


connection.start().catch((err) => console.log("Meh can't start", err));


const sendMessage = () => {
connection.invoke("SendMessage", '123', '222', msg)

}

</script>

<svelte:head>
	<title>Admin Portal | Chat</title>
</svelte:head>

<section>
    <h1>Chat Tester</h1>
        <textarea value={serverData} class='big-box' disabled/>
        <input placeholder="Type Message" value={msg} on:change={(event) => msg = (event.currentTarget.value)}/>
        <button on:click={sendMessage}>Send it</button>
</section>

<style>
    .big-box {
    width: 100%;
    min-height: 50%;
    padding-bottom: 50px;
    margin-bottom: 100px;
    }


    input {
    width: 60%;
    padding-bottom: 35px;
    margin-bottom: 30px;
    }

	section {
		display: flex;
		flex-direction: column;
		justify-content: center;
		align-items: center;
		flex: 1;
	}

	h1 {
		width: 100%;
	}
</style>

