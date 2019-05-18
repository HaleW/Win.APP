// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: AppInfoProto.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace Win.App.Protobuf.Src {

  /// <summary>Holder for reflection information generated from AppInfoProto.proto</summary>
  public static partial class AppInfoProtoReflection {

    #region Descriptor
    /// <summary>File descriptor for AppInfoProto.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static AppInfoProtoReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "ChJBcHBJbmZvUHJvdG8ucHJvdG8SFFdpbi5BcHAuUHJvdG9idWYuU3JjIrEB",
            "CgxBcHBJbmZvUHJvdG8SCgoCSWQYASABKAUSDAoETmFtZRgCIAEoCRILCgNJ",
            "bWcYAyABKAkSEAoIRGVzY3JpYmUYBCABKAkSEwoLRG93bmxvYWRVcmwYBSAB",
            "KAkSEQoJRG93bmxvYWRzGAYgASgFEg8KB1ZlcnNpb24YByABKAkSEgoKVXBk",
            "YXRlVGltZRgIIAEoCRINCgVTY29yZRgJIAEoARIMCgRUeXBlGAogASgJYgZw",
            "cm90bzM="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::Win.App.Protobuf.Src.AppInfoProto), global::Win.App.Protobuf.Src.AppInfoProto.Parser, new[]{ "Id", "Name", "Img", "Describe", "DownloadUrl", "Downloads", "Version", "UpdateTime", "Score", "Type" }, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class AppInfoProto : pb::IMessage<AppInfoProto> {
    private static readonly pb::MessageParser<AppInfoProto> _parser = new pb::MessageParser<AppInfoProto>(() => new AppInfoProto());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<AppInfoProto> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Win.App.Protobuf.Src.AppInfoProtoReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public AppInfoProto() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public AppInfoProto(AppInfoProto other) : this() {
      id_ = other.id_;
      name_ = other.name_;
      img_ = other.img_;
      describe_ = other.describe_;
      downloadUrl_ = other.downloadUrl_;
      downloads_ = other.downloads_;
      version_ = other.version_;
      updateTime_ = other.updateTime_;
      score_ = other.score_;
      type_ = other.type_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public AppInfoProto Clone() {
      return new AppInfoProto(this);
    }

    /// <summary>Field number for the "Id" field.</summary>
    public const int IdFieldNumber = 1;
    private int id_;
    /// <summary>
    //// &lt;summary>
    //// Id
    //// &lt;/summary>
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int Id {
      get { return id_; }
      set {
        id_ = value;
      }
    }

    /// <summary>Field number for the "Name" field.</summary>
    public const int NameFieldNumber = 2;
    private string name_ = "";
    /// <summary>
    //// &lt;summary>
    //// 应用名
    //// &lt;/summary>
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Name {
      get { return name_; }
      set {
        name_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "Img" field.</summary>
    public const int ImgFieldNumber = 3;
    private string img_ = "";
    /// <summary>
    //// &lt;summary>
    //// 应用图片
    //// &lt;/summary>
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Img {
      get { return img_; }
      set {
        img_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "Describe" field.</summary>
    public const int DescribeFieldNumber = 4;
    private string describe_ = "";
    /// <summary>
    //// &lt;summary>
    //// 应用描述
    //// &lt;/summary>
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Describe {
      get { return describe_; }
      set {
        describe_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "DownloadUrl" field.</summary>
    public const int DownloadUrlFieldNumber = 5;
    private string downloadUrl_ = "";
    /// <summary>
    //// &lt;summary>
    //// 应用下载URL
    //// &lt;/summary>
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string DownloadUrl {
      get { return downloadUrl_; }
      set {
        downloadUrl_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "Downloads" field.</summary>
    public const int DownloadsFieldNumber = 6;
    private int downloads_;
    /// <summary>
    //// &lt;summary>
    //// 应用下载次数
    //// &lt;/summary>
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int Downloads {
      get { return downloads_; }
      set {
        downloads_ = value;
      }
    }

    /// <summary>Field number for the "Version" field.</summary>
    public const int VersionFieldNumber = 7;
    private string version_ = "";
    /// <summary>
    //// &lt;summary>
    //// 应用版本
    //// &lt;/summary>
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Version {
      get { return version_; }
      set {
        version_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "UpdateTime" field.</summary>
    public const int UpdateTimeFieldNumber = 8;
    private string updateTime_ = "";
    /// <summary>
    //// &lt;summary>
    //// 应用更新时间
    //// &lt;/summary>
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string UpdateTime {
      get { return updateTime_; }
      set {
        updateTime_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "Score" field.</summary>
    public const int ScoreFieldNumber = 9;
    private double score_;
    /// <summary>
    //// &lt;summary>
    //// 应用评分
    //// &lt;/summary>
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public double Score {
      get { return score_; }
      set {
        score_ = value;
      }
    }

    /// <summary>Field number for the "Type" field.</summary>
    public const int TypeFieldNumber = 10;
    private string type_ = "";
    /// <summary>
    //// &lt;summary>
    //// 应用类型
    //// &lt;/summary>
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Type {
      get { return type_; }
      set {
        type_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as AppInfoProto);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(AppInfoProto other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Id != other.Id) return false;
      if (Name != other.Name) return false;
      if (Img != other.Img) return false;
      if (Describe != other.Describe) return false;
      if (DownloadUrl != other.DownloadUrl) return false;
      if (Downloads != other.Downloads) return false;
      if (Version != other.Version) return false;
      if (UpdateTime != other.UpdateTime) return false;
      if (!pbc::ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Score, other.Score)) return false;
      if (Type != other.Type) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Id != 0) hash ^= Id.GetHashCode();
      if (Name.Length != 0) hash ^= Name.GetHashCode();
      if (Img.Length != 0) hash ^= Img.GetHashCode();
      if (Describe.Length != 0) hash ^= Describe.GetHashCode();
      if (DownloadUrl.Length != 0) hash ^= DownloadUrl.GetHashCode();
      if (Downloads != 0) hash ^= Downloads.GetHashCode();
      if (Version.Length != 0) hash ^= Version.GetHashCode();
      if (UpdateTime.Length != 0) hash ^= UpdateTime.GetHashCode();
      if (Score != 0D) hash ^= pbc::ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Score);
      if (Type.Length != 0) hash ^= Type.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (Id != 0) {
        output.WriteRawTag(8);
        output.WriteInt32(Id);
      }
      if (Name.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(Name);
      }
      if (Img.Length != 0) {
        output.WriteRawTag(26);
        output.WriteString(Img);
      }
      if (Describe.Length != 0) {
        output.WriteRawTag(34);
        output.WriteString(Describe);
      }
      if (DownloadUrl.Length != 0) {
        output.WriteRawTag(42);
        output.WriteString(DownloadUrl);
      }
      if (Downloads != 0) {
        output.WriteRawTag(48);
        output.WriteInt32(Downloads);
      }
      if (Version.Length != 0) {
        output.WriteRawTag(58);
        output.WriteString(Version);
      }
      if (UpdateTime.Length != 0) {
        output.WriteRawTag(66);
        output.WriteString(UpdateTime);
      }
      if (Score != 0D) {
        output.WriteRawTag(73);
        output.WriteDouble(Score);
      }
      if (Type.Length != 0) {
        output.WriteRawTag(82);
        output.WriteString(Type);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Id != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(Id);
      }
      if (Name.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Name);
      }
      if (Img.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Img);
      }
      if (Describe.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Describe);
      }
      if (DownloadUrl.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(DownloadUrl);
      }
      if (Downloads != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(Downloads);
      }
      if (Version.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Version);
      }
      if (UpdateTime.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(UpdateTime);
      }
      if (Score != 0D) {
        size += 1 + 8;
      }
      if (Type.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Type);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(AppInfoProto other) {
      if (other == null) {
        return;
      }
      if (other.Id != 0) {
        Id = other.Id;
      }
      if (other.Name.Length != 0) {
        Name = other.Name;
      }
      if (other.Img.Length != 0) {
        Img = other.Img;
      }
      if (other.Describe.Length != 0) {
        Describe = other.Describe;
      }
      if (other.DownloadUrl.Length != 0) {
        DownloadUrl = other.DownloadUrl;
      }
      if (other.Downloads != 0) {
        Downloads = other.Downloads;
      }
      if (other.Version.Length != 0) {
        Version = other.Version;
      }
      if (other.UpdateTime.Length != 0) {
        UpdateTime = other.UpdateTime;
      }
      if (other.Score != 0D) {
        Score = other.Score;
      }
      if (other.Type.Length != 0) {
        Type = other.Type;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 8: {
            Id = input.ReadInt32();
            break;
          }
          case 18: {
            Name = input.ReadString();
            break;
          }
          case 26: {
            Img = input.ReadString();
            break;
          }
          case 34: {
            Describe = input.ReadString();
            break;
          }
          case 42: {
            DownloadUrl = input.ReadString();
            break;
          }
          case 48: {
            Downloads = input.ReadInt32();
            break;
          }
          case 58: {
            Version = input.ReadString();
            break;
          }
          case 66: {
            UpdateTime = input.ReadString();
            break;
          }
          case 73: {
            Score = input.ReadDouble();
            break;
          }
          case 82: {
            Type = input.ReadString();
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code