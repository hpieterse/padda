// Not documented and may change in future versions of mono
// The current source code of the BINDING functions:
// https://github.com/mono/mono/blob/b6ef72c244bd33623d231ff05bc3d120ad36b4e9/sdks/wasm/src/binding_support.js

window.unmarshalledModules = {};

window.getUnmarshalledModule = (rawImportId) => {
  const importId = BINDING.conv_string(rawImportId);
  return window.unmarshalledModules[importId];
}

export const unmarshalledImport = async (filePath) => {
  const importId = Math.random().toString(36).substring(7);

  var module = await eval(`import('${filePath}')`);

  window.unmarshalledModules[importId] = module;
  return importId;
}
