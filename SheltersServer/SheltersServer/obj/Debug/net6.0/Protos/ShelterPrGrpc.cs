// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/ShelterPr.proto
// </auto-generated>
#pragma warning disable 0414, 1591, 8981, 0612
#region Designer generated code

using grpc = global::Grpc.Core;

namespace ClientShelters {
  public static partial class ShelterPr
  {
    static readonly string __ServiceName = "ShelterPr.ShelterPr";

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static void __Helper_SerializeMessage(global::Google.Protobuf.IMessage message, grpc::SerializationContext context)
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (message is global::Google.Protobuf.IBufferMessage)
      {
        context.SetPayloadLength(message.CalculateSize());
        global::Google.Protobuf.MessageExtensions.WriteTo(message, context.GetBufferWriter());
        context.Complete();
        return;
      }
      #endif
      context.Complete(global::Google.Protobuf.MessageExtensions.ToByteArray(message));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static class __Helper_MessageCache<T>
    {
      public static readonly bool IsBufferMessage = global::System.Reflection.IntrospectionExtensions.GetTypeInfo(typeof(global::Google.Protobuf.IBufferMessage)).IsAssignableFrom(typeof(T));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static T __Helper_DeserializeMessage<T>(grpc::DeserializationContext context, global::Google.Protobuf.MessageParser<T> parser) where T : global::Google.Protobuf.IMessage<T>
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (__Helper_MessageCache<T>.IsBufferMessage)
      {
        return parser.ParseFrom(context.PayloadAsReadOnlySequence());
      }
      #endif
      return parser.ParseFrom(context.PayloadAsNewBuffer());
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::ClientShelters.AddShelterRequest> __Marshaller_ShelterPr_AddShelterRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::ClientShelters.AddShelterRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::ClientShelters.isCorrectShelt> __Marshaller_ShelterPr_isCorrectShelt = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::ClientShelters.isCorrectShelt.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::ClientShelters.DeleteShelterRequest> __Marshaller_ShelterPr_DeleteShelterRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::ClientShelters.DeleteShelterRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::ClientShelters.GetSheltersRequest> __Marshaller_ShelterPr_GetSheltersRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::ClientShelters.GetSheltersRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::ClientShelters.SheltersReply> __Marshaller_ShelterPr_SheltersReply = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::ClientShelters.SheltersReply.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::ClientShelters.OnlyUser> __Marshaller_ShelterPr_OnlyUser = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::ClientShelters.OnlyUser.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::SheltersServer.CitiesReply> __Marshaller_Data_CitiesReply = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::SheltersServer.CitiesReply.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::ClientShelters.ShelterRequest> __Marshaller_ShelterPr_ShelterRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::ClientShelters.ShelterRequest.Parser));

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::ClientShelters.AddShelterRequest, global::ClientShelters.isCorrectShelt> __Method_CreateShelter = new grpc::Method<global::ClientShelters.AddShelterRequest, global::ClientShelters.isCorrectShelt>(
        grpc::MethodType.Unary,
        __ServiceName,
        "CreateShelter",
        __Marshaller_ShelterPr_AddShelterRequest,
        __Marshaller_ShelterPr_isCorrectShelt);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::ClientShelters.DeleteShelterRequest, global::ClientShelters.isCorrectShelt> __Method_DeleteShelter = new grpc::Method<global::ClientShelters.DeleteShelterRequest, global::ClientShelters.isCorrectShelt>(
        grpc::MethodType.Unary,
        __ServiceName,
        "DeleteShelter",
        __Marshaller_ShelterPr_DeleteShelterRequest,
        __Marshaller_ShelterPr_isCorrectShelt);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::ClientShelters.GetSheltersRequest, global::ClientShelters.SheltersReply> __Method_GetShelters = new grpc::Method<global::ClientShelters.GetSheltersRequest, global::ClientShelters.SheltersReply>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetShelters",
        __Marshaller_ShelterPr_GetSheltersRequest,
        __Marshaller_ShelterPr_SheltersReply);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::ClientShelters.OnlyUser, global::SheltersServer.CitiesReply> __Method_GetCitites = new grpc::Method<global::ClientShelters.OnlyUser, global::SheltersServer.CitiesReply>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetCitites",
        __Marshaller_ShelterPr_OnlyUser,
        __Marshaller_Data_CitiesReply);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::ClientShelters.ShelterRequest, global::ClientShelters.isCorrectShelt> __Method_UpdateShelter = new grpc::Method<global::ClientShelters.ShelterRequest, global::ClientShelters.isCorrectShelt>(
        grpc::MethodType.Unary,
        __ServiceName,
        "UpdateShelter",
        __Marshaller_ShelterPr_ShelterRequest,
        __Marshaller_ShelterPr_isCorrectShelt);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::ClientShelters.ShelterPrReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of ShelterPr</summary>
    [grpc::BindServiceMethod(typeof(ShelterPr), "BindService")]
    public abstract partial class ShelterPrBase
    {
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::ClientShelters.isCorrectShelt> CreateShelter(global::ClientShelters.AddShelterRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::ClientShelters.isCorrectShelt> DeleteShelter(global::ClientShelters.DeleteShelterRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::ClientShelters.SheltersReply> GetShelters(global::ClientShelters.GetSheltersRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::SheltersServer.CitiesReply> GetCitites(global::ClientShelters.OnlyUser request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::ClientShelters.isCorrectShelt> UpdateShelter(global::ClientShelters.ShelterRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static grpc::ServerServiceDefinition BindService(ShelterPrBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_CreateShelter, serviceImpl.CreateShelter)
          .AddMethod(__Method_DeleteShelter, serviceImpl.DeleteShelter)
          .AddMethod(__Method_GetShelters, serviceImpl.GetShelters)
          .AddMethod(__Method_GetCitites, serviceImpl.GetCitites)
          .AddMethod(__Method_UpdateShelter, serviceImpl.UpdateShelter).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static void BindService(grpc::ServiceBinderBase serviceBinder, ShelterPrBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_CreateShelter, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::ClientShelters.AddShelterRequest, global::ClientShelters.isCorrectShelt>(serviceImpl.CreateShelter));
      serviceBinder.AddMethod(__Method_DeleteShelter, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::ClientShelters.DeleteShelterRequest, global::ClientShelters.isCorrectShelt>(serviceImpl.DeleteShelter));
      serviceBinder.AddMethod(__Method_GetShelters, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::ClientShelters.GetSheltersRequest, global::ClientShelters.SheltersReply>(serviceImpl.GetShelters));
      serviceBinder.AddMethod(__Method_GetCitites, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::ClientShelters.OnlyUser, global::SheltersServer.CitiesReply>(serviceImpl.GetCitites));
      serviceBinder.AddMethod(__Method_UpdateShelter, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::ClientShelters.ShelterRequest, global::ClientShelters.isCorrectShelt>(serviceImpl.UpdateShelter));
    }

  }
}
#endregion
