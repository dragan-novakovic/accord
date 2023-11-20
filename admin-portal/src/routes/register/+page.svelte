<script lang="ts">
	import { useForm, HintGroup, Hint } from 'svelte-use-form';
	import { goto } from '$app/navigation';

	const form = useForm();
	interface RegisterResponse {
		id: string;
		status: number;
		statusText: string;
		token: null;
		username: string;
	}

	const Register = async () => {
		const { username, password } = $form.values;

		console.log(username, password);

		const response = await fetch('http://localhost:1993/auth/register', {
			method: 'POST',
			body: JSON.stringify({ username, password })
		});
		const data: RegisterResponse = await response.json();

		if (data.status === 201) {
			goto('/login');
		}
	};
</script>

<svelte:head>
	<title>Admin Portal | Register</title>
</svelte:head>

<section>
	<h1>Register</h1>
</section>
<form use:form>
	<input type="username" name="username" />
	<HintGroup for="username">
		<Hint on="required">This is a mandatory field</Hint>
		<Hint on="username" hideWhenRequired>Email is not valid</Hint>
	</HintGroup>

	<input type="password" name="password" />
	<Hint for="password" on="required">This is a mandatory field</Hint>
	<button on:click={Register}>Register</button>
</form>
<pre>
<!-- {JSON.stringify($form, null, ' ')} -->
</pre>

<style>
	:global(.touched:invalid) {
		border-color: red;
		outline-color: red;
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
