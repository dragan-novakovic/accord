<script context="module" lang="ts">
	export const prerender = true;
</script>

<script lang="ts">
	import { HubConnectionBuilder, HttpTransportType, LogLevel } from '@microsoft/signalr';
	import { onMount } from 'svelte';

	let connection = new HubConnectionBuilder()
		.withUrl('http://localhost:5207/chat', {
			withCredentials: false,
			skipNegotiation: true,
			transport: HttpTransportType.WebSockets
		})
		.configureLogging(LogLevel.Trace)
		.build();

	// Prebaci u state-managment
	let serverData = null;
	let msg: string | null = null;
	let userData: any = { username: 'Default' };
	let ReceiverId: string | null = null;

	onMount(() => {
		connection.start().then(() => {
	const userDataStorage = localStorage.getItem('userData');
		if (!userDataStorage) {
			alert('Login First');
		} else {
			userData = JSON.parse(userDataStorage);
			connection.send('AddToCache', userData.id);
		}

}).catch((e) => console.log('On Mount Err', e));
		
	
	});

	connection.on('send', (data) => {
		console.log('Zasto zoves send?', data);
	});
	connection.on('ReceiveMessage', (data) => {
		console.log('Response', data);
		serverData = serverData ? serverData + data : data;
	});


	const sendMessage = () => {
		connection.invoke('SendMessage', userData.id, msg, ReceiverId, ReceiverId);
	};
</script>

<svelte:head>
	<title>Admin Portal | Chat</title>
</svelte:head>

<section>
	<h1>Chat Tester # {userData.username}</h1>
	<h2>Id: {userData.id}</h2>
	<div class="main">
		<div>
			<input
				placeholder="Receiver Id"
				value={ReceiverId}
				on:change={(event) => (ReceiverId = event.currentTarget.value)}
			/>
			<input
				placeholder="Type Message"
				value={msg}
				on:change={(event) => (msg = event.currentTarget.value)}
			/>
		</div>
		<textarea value={serverData} class="big-box" disabled />
	</div>

	<button on:click={sendMessage}>Send it</button>
</section>

<style>
	.big-box {
		width: 100%;
		min-height: 50%;
		padding-bottom: 50px;
		margin-bottom: 80px;
	}

	.main {
		display: flex;
	}

	input {
		width: 70%;
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
