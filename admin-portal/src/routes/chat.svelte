<script context="module" lang="ts">
	export const prerender = true;
</script>

<script lang="ts">
    import {HubConnectionBuilder, HttpTransportType} from '@microsoft/signalr';
import { onMount } from 'svelte';


let connection = new HubConnectionBuilder()
    .withUrl("http://localhost:5207/chat", {withCredentials: false, skipNegotiation: true, transport: HttpTransportType.WebSockets})
    .build();

let serverData = null;
onMount(() => {

connection.start().catch(() => console.log("I KNOW"));
    })

	
connection.on("send", data => {
    console.log(data);
});

connection.on('receive', data => {
    console.log("Receiving", data)
    serverData = serverData ? serverData + data : data;
})

    let msg = null;

connection.start().catch((err) => console.log("Meh can't start"));
</script>

<svelte:head>
	<title>Admin Portal | Chat</title>
</svelte:head>

<section>
    <h1>Chat Tester</h1>
        <textarea value={serverData} />
        <input placeholder="Type Message" value={msg} on:change={(event) => msg = (event.currentTarget.value)}/>
        <button on:click={() => {console.log(msg);connection.invoke("send", msg)}}>Send it</button>
</section>

<style>
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

