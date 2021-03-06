// Generated by the protocol buffer compiler.  DO NOT EDIT!
// source: S_Exception.proto
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace Nanomite.Common {

  /// <summary>Holder for reflection information generated from S_Exception.proto</summary>
  public static partial class SExceptionReflection {

    #region Descriptor
    /// <summary>File descriptor for S_Exception.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static SExceptionReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "ChFTX0V4Y2VwdGlvbi5wcm90bxIPTmFub21pdGUuQ29tbW9uInYKC1NfRXhj",
            "ZXB0aW9uEgwKBENvZGUYASABKAkSDwoHTWVzc2FnZRgCIAEoCRISCgpTdGFj",
            "a1RyYWNlGAMgASgJEjQKDklubmVyRXhjZXB0aW9uGAQgASgLMhwuTmFub21p",
            "dGUuQ29tbW9uLlNfRXhjZXB0aW9uQisKD2lvLmdycGMubWVzc2FnZUIQTWVz",
            "c2FnZURhdGFQcm90b1ABogIDSExXYgZwcm90bzM="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::Nanomite.Common.S_Exception), global::Nanomite.Common.S_Exception.Parser, new[]{ "Code", "Message", "StackTrace", "InnerException" }, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class S_Exception : pb::IMessage<S_Exception> {
    private static readonly pb::MessageParser<S_Exception> _parser = new pb::MessageParser<S_Exception>(() => new S_Exception());
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<S_Exception> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Nanomite.Common.SExceptionReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public S_Exception() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public S_Exception(S_Exception other) : this() {
      code_ = other.code_;
      message_ = other.message_;
      stackTrace_ = other.stackTrace_;
      InnerException = other.innerException_ != null ? other.InnerException.Clone() : null;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public S_Exception Clone() {
      return new S_Exception(this);
    }

    /// <summary>Field number for the "Code" field.</summary>
    public const int CodeFieldNumber = 1;
    private string code_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Code {
      get { return code_; }
      set {
        code_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "Message" field.</summary>
    public const int MessageFieldNumber = 2;
    private string message_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Message {
      get { return message_; }
      set {
        message_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "StackTrace" field.</summary>
    public const int StackTraceFieldNumber = 3;
    private string stackTrace_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string StackTrace {
      get { return stackTrace_; }
      set {
        stackTrace_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "InnerException" field.</summary>
    public const int InnerExceptionFieldNumber = 4;
    private global::Nanomite.Common.S_Exception innerException_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::Nanomite.Common.S_Exception InnerException {
      get { return innerException_; }
      set {
        innerException_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as S_Exception);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(S_Exception other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Code != other.Code) return false;
      if (Message != other.Message) return false;
      if (StackTrace != other.StackTrace) return false;
      if (!object.Equals(InnerException, other.InnerException)) return false;
      return true;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Code.Length != 0) hash ^= Code.GetHashCode();
      if (Message.Length != 0) hash ^= Message.GetHashCode();
      if (StackTrace.Length != 0) hash ^= StackTrace.GetHashCode();
      if (innerException_ != null) hash ^= InnerException.GetHashCode();
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (Code.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(Code);
      }
      if (Message.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(Message);
      }
      if (StackTrace.Length != 0) {
        output.WriteRawTag(26);
        output.WriteString(StackTrace);
      }
      if (innerException_ != null) {
        output.WriteRawTag(34);
        output.WriteMessage(InnerException);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Code.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Code);
      }
      if (Message.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Message);
      }
      if (StackTrace.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(StackTrace);
      }
      if (innerException_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(InnerException);
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(S_Exception other) {
      if (other == null) {
        return;
      }
      if (other.Code.Length != 0) {
        Code = other.Code;
      }
      if (other.Message.Length != 0) {
        Message = other.Message;
      }
      if (other.StackTrace.Length != 0) {
        StackTrace = other.StackTrace;
      }
      if (other.innerException_ != null) {
        if (innerException_ == null) {
          innerException_ = new global::Nanomite.Common.S_Exception();
        }
        InnerException.MergeFrom(other.InnerException);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            input.SkipLastField();
            break;
          case 10: {
            Code = input.ReadString();
            break;
          }
          case 18: {
            Message = input.ReadString();
            break;
          }
          case 26: {
            StackTrace = input.ReadString();
            break;
          }
          case 34: {
            if (innerException_ == null) {
              innerException_ = new global::Nanomite.Common.S_Exception();
            }
            input.ReadMessage(innerException_);
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code
