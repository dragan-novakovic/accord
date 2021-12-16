<script context="module" lang="ts">
	export const prerender = true;
</script>

<script lang="ts">
    import {HubConnectionBuilder} from '@microsoft/signalr';
import { onMount } from 'svelte';


let connection = new HubConnectionBuilder()
    .withUrl("http://localhost:5207/chat", {withCredentials: false})
    .build();

let serverData = null;
onMount(() => {

connection.start().catch(() => console.log("I KNOW"));
    })

	
connection.on("send", data => {
    console.log(data);
});

connection.on('receive', data => {
    serverData = data;
})

    let msg = null;

connection.start()
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

