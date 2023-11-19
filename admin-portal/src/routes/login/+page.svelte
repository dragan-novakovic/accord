<script lang="ts">
	import { useForm, validators, HintGroup, Hint, email, required } from 'svelte-use-form';

	const form = useForm();

	const login = async () => {
		const { username, password } = $form.values;

		const response = await fetch('http://localhost:1993/auth/login', {
			method: 'POST',
			body: JSON.stringify({ username, password })
		});
		const data = await response.json();
		console.log({ data });

		localStorage.setItem('userData', JSON.stringify(data));
	};
</script>

<svelte:head>
	<title>Admin Portal | Login</title>
</svelte:head>

<section>
	<h1>Login</h1>
</section>
<form use:form>
	<input type="username" name="username" />
	<HintGroup for="username">
		<Hint on="required">This is a mandatory field</Hint>
		<Hint on="username" hideWhenRequired>Email is not valid</Hint>
	</HintGroup>

	<input type="password" name="password" use:validators={[required]} />
	<Hint for="password" on="required">This is a mandatory field</Hint>

	<button on:click={login}>Login</button>
</form>

<style>
	:global(.touched:invalid) {
		border-color: red;
		outline-color: red;
	}

	form {
		padding-bottom: 20em;
		display: flex;
		flex-direction: row;
		justify-content: center;
		align-items: center;
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
