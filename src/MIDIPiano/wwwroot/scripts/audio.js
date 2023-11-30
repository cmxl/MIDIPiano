const _gainNodes = [];
let _volume = 0.5;

function setVolume(volume) {
	_volume = volume;
}

async function play(src) {
	const context = new AudioContext();
	const gainNode = context.createGain();
	_gainNodes.push(gainNode);

	const source = context.createBufferSource();
	source.buffer = await fetch(src)
		.then(res => res.arrayBuffer())
		.then(ArrayBuffer => context.decodeAudioData(ArrayBuffer));

	source.connect(gainNode);
	gainNode.connect(context.destination);
	gainNode.gain.setValueAtTime(_volume, context.currentTime);
	source.start();
}